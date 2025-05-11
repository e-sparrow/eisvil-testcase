using Game.Enemies;
using Game.Tasks;
using UnityEngine;
using Zenject;

namespace Game.Core
{
    public sealed class CoreInstaller
        : MonoInstaller
    {
        [SerializeField] private EnemiesConfiguration enemiesConfiguration;
        
        [SerializeField] private TasksConfiguration tasksConfiguration;
        [SerializeField] private TaskServiceParameters taskServiceParameters;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<TimerService>()
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<EnemyService>()
                .AsSingle()
                .WithArguments(enemiesConfiguration);

            Container
                .BindInterfacesAndSelfTo<TaskService>()
                .AsSingle()
                .WithArguments(tasksConfiguration, taskServiceParameters);
        }
    }
}