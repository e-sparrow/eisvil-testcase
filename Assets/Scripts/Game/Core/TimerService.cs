using Game.Tasks;
using UnityEngine;
using Zenject;

namespace Game.Core
{
    public sealed class TimerService
        : ITickable
    {
        public TimerService(TaskService taskService)
        {
            _taskService = taskService;
        }

        private readonly TaskService _taskService;
        
        public void Tick()
        {
            var signal = new TaskSignal(ETaskType.Time, Time.deltaTime);
            _taskService.HandleSignal(signal);
        }
    }
}