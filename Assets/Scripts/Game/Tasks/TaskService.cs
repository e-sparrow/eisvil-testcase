using System;
using System.Collections.Generic;
using Birdhouse.Common.Extensions;
using Birdhouse.Tools.Signals;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Game.Tasks
{
    public sealed class TaskService
        : IInitializable, IDisposable
    {
        public TaskService(TasksConfiguration configuration, TaskServiceParameters parameters)
        {
            _configuration = configuration;
            _parameters = parameters;
        }

        private readonly TasksConfiguration _configuration;
        private readonly TaskServiceParameters _parameters;

        private readonly IDictionary<ETaskType, ICollection<Task>> _tasks = new Dictionary<ETaskType, ICollection<Task>>();

        private IDisposable _busToken;
        
        public void Initialize()
        {
            _busToken = ContextBus<TaskService>
                .GetOrCreateBus<TaskSignal>()
                .Subscribe<TaskSignal>(HandleSignal);

            foreach (var scriptableTask in _configuration.Tasks)
            {
                var task = new Task(scriptableTask);
                
                if (!_tasks.ContainsKey(scriptableTask.Type))
                {
                    _tasks[scriptableTask.Type] = new List<Task>();
                }
                
                _tasks[scriptableTask.Type].Add(task);

                var view = Object.Instantiate(_configuration.ViewPrefab, _parameters.TaskViewParent);
                
                HandleAmountChanged(0);

                task.OnAmountChanged += HandleAmountChanged;
                task.OnTaskFinished += HandleTaskFinished;

                void HandleAmountChanged(float amount)
                {
                    var description = scriptableTask.GetDescription(amount, scriptableTask.Id);
                    view.SetDescription(description);
                    
                    view.SetProgress(task.Progress);
                }

                void HandleTaskFinished()
                {
                    view.SetFinished();
                }
            }
        }

        public void Dispose()
        {
            _busToken.Dispose();
            _tasks.Clear();
        }

        public void HandleSignal(TaskSignal signal)
        {
            _tasks[signal.Type].Foreach(value => value.HandleSignal(signal));
        }
    }

    [Serializable]
    public struct TaskServiceParameters
    {
        [field: SerializeField]
        public Transform TaskViewParent
        {
            get;
            private set;
        }
    }
}