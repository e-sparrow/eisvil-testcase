using Game.Enemies;
using UnityEngine;

namespace Game.Tasks
{
    [CreateAssetMenu(menuName = "Game/Tasks/Kill Task", fileName = "Kill Task")]
    public sealed class KillTask
        : ScriptableTaskBase
    {
        public override ETaskType Type => ETaskType.Kill;
        public override bool IgnoreId => killAny;
        public override int Id => (int) type;
        
        [SerializeField] private bool killAny;
        [SerializeField] private string format;
        [SerializeField] private EEnemyType type;

        public override string GetDescription(float amount, int id)
        {
            var realAmount = Mathf.RoundToInt(amount);

            var result = string.Format(format, realAmount, Amount);
            return result;
        }
    }
}