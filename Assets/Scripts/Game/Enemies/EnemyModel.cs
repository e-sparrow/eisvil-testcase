using System;

namespace Game.Enemies
{
    public sealed class EnemyModel
    {
        public EnemyModel(EEnemyType type, int clicksToKill)
        {
            Type = type;
            ClicksToKill = clicksToKill;
        }

        public event Action OnDie = () => { };

        public EEnemyType Type
        {
            get;
        }
        
        public int ClicksToKill
        {
            get;
        }

        public void Die()
        {
            OnDie.Invoke();
        }
    }
}