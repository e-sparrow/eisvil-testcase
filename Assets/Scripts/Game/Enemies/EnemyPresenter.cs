using System;
using Birdhouse.Tools.Signals;
using Game.Tasks;
using Zenject;

namespace Game.Enemies
{
    public sealed class EnemyPresenter
        : IInitializable, IDisposable
    {
        public EnemyPresenter(EnemyModel model, EnemyView view)
        {
            _model = model;
            _view = view;
        }

        private readonly EnemyModel _model;
        private readonly EnemyView _view;

        private int _clicks;

        public void Initialize()
        {
            _view.OnClick += HandleClick;
        }

        public void Dispose()
        {
            _view.OnClick -= HandleClick;
        }

        private void HandleClick()
        {
            _clicks++;

            if (_clicks >= _model.ClicksToKill)
            {
                _view.Die();
                _model.Die();
                Dispose();

                var signal = new TaskSignal(ETaskType.Kill, 1, (int) _model.Type);
                ContextBus<TaskService>
                    .GetOrCreateBus<TaskSignal>()
                    .Fire(signal);
            }
        }
    }
}