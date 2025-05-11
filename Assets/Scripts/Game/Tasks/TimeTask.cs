using System;
using UnityEngine;

namespace Game.Tasks
{
    [CreateAssetMenu(menuName = "Game/Tasks/Time Task", fileName = "Time Task")]
    public sealed class TimeTask
        : ScriptableTaskBase
    {
        public override ETaskType Type => ETaskType.Time;
        public override bool IgnoreId => true;

        [SerializeField] private string format;
        
        public override string GetDescription(float amount, int id)
        {
            var realAmount = TimeSpan.FromSeconds(amount).ToString("mm\\:ss");
            var target = TimeSpan.FromSeconds(Amount).ToString("mm\\:ss");
            
            var result = string.Format(format, realAmount, target);
            return result;
        }
    }
}