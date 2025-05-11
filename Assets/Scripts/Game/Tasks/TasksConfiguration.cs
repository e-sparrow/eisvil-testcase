using System.Collections.Generic;
using UnityEngine;

namespace Game.Tasks
{
    [CreateAssetMenu(menuName = "Game/Tasks/Configuration", fileName = "TasksConfiguration")]
    public sealed class TasksConfiguration
        : ScriptableObject
    {
        public IEnumerable<ScriptableTaskBase> Tasks => tasks;

        [field: SerializeField]
        public TaskView ViewPrefab
        {
            get;
            private set;
        }
        
        [SerializeField] private List<ScriptableTaskBase> tasks;
    }
}