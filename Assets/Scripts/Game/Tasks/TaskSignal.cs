namespace Game.Tasks
{
    public readonly struct TaskSignal
    {
        public TaskSignal(ETaskType type, float amount, int id = 0)
        {
            Type = type;
            Amount = amount;
            Id = id;
        }

        public ETaskType Type
        {
            get;
        }

        public float Amount
        {
            get;
        }

        public int Id
        {
            get;
        }
    }
}