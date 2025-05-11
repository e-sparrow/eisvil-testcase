using System;
using Birdhouse.Tools.Signals;
using Game.Enemies;
using UnityEngine;
using Zenject;

namespace Game.Tasks
{
    public sealed class Task
    {
        public Task(ScriptableTaskBase inner)
        {
            _inner = inner;
        }

        public event Action<float> OnAmountChanged = _ => { };
        public event Action OnTaskFinished = () => { };

        private readonly ScriptableTaskBase _inner;

        private IDisposable _busToken;
        private float _currentAmount;

        public ETaskType Type => _inner.Type;
        public float Progress => _currentAmount / _inner.Amount;
        public bool IsFinished => Progress >= 1f;

        public void HandleSignal(TaskSignal signal)
        {
            if (signal.Type != _inner.Type)
            {
                return;
            }
            
            if (!_inner.IgnoreId && signal.Id != _inner.Id)
            {
                return;
            }
            
            _currentAmount += signal.Amount;
            OnAmountChanged.Invoke(_currentAmount);
            
            if (_currentAmount >= _inner.Amount)
            {
                OnTaskFinished.Invoke();
            }
        }
    }
}