using System;
using System.Collections.Generic;
using Birdhouse.Common.Extensions;
using Birdhouse.Common.Helpers;
using Zenject;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Game.Enemies
{
    public sealed class EnemyService
        : IInitializable, IDisposable
    {
        public EnemyService(EnemiesConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly EnemiesConfiguration _configuration;

        private readonly ICollection<EnemyPresenter> _presenters = new List<EnemyPresenter>();

        public void Initialize()
        {
            for (var i = 0; i < _configuration.EnemiesAmount; i++)
            {
                var type = (EEnemyType) EnumsHelper<EEnemyType>.GetRandom();
                var configuration = _configuration.GetConfiguration(type);
                
                var model = new EnemyModel(type, configuration.ClicksToKill);
                var view = Object.Instantiate(_configuration.EnemyPrefab);
                view.SetSprite(configuration.Sprite);
                view.SetColor(configuration.Color);
                view.SetSize(configuration.Size);

                var presenter = new EnemyPresenter(model, view);
                presenter.Initialize();
                _presenters.Add(presenter);

                var position = _configuration.SpawnRect.GetRandomRectPoint();
                view.transform.position = position;
            }
        }

        public void Dispose()
        {
            foreach (var presenter in _presenters)
            {
                presenter.Dispose();
            }
            
            _presenters.Clear();
        }
    }
}