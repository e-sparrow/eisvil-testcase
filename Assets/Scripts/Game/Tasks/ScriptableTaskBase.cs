using UnityEngine;

namespace Game.Tasks
{
    public abstract class ScriptableTaskBase
        : ScriptableObject
    {
        public abstract ETaskType Type
        {
            get;
        }

        public abstract bool IgnoreId
        {
            get;
        }

        public virtual int Id
        {
            get;
        } = 0;

        [field: SerializeField]
        public float Amount
        {
            get;
            private set;
        }

        public abstract string GetDescription(float amount, int id);
    }
}