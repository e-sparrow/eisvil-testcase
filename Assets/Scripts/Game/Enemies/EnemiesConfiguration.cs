using System;
using System.Collections.Generic;
using System.Linq;
using Birdhouse.Common.Generic.Pairs;
using UnityEngine;

namespace Game.Enemies
{
    [CreateAssetMenu(menuName = "Game/Enemies/Configuration", fileName = "EnemiesConfiguration")]
    public sealed class EnemiesConfiguration
        : ScriptableObject
    {
        [SerializeField] private List<SerializablePair<EEnemyType, EnemyTypeConfiguration>> configurations;

        [field: SerializeField]
        public int EnemiesAmount
        {
            get;
            private set;
        }

        [field: SerializeField]
        public EnemyView EnemyPrefab
        {
            get;
            private set;
        }

        [field: SerializeField]
        public Rect SpawnRect
        {
            get;
            private set;
        }

        public EnemyTypeConfiguration GetConfiguration(EEnemyType type)
        {
            var result = configurations.FirstOrDefault(value => value.Key == type).Value;
            return result;
        }
    }
    
    [Serializable]
    public struct EnemyTypeConfiguration
    {
        [field: SerializeField]
        public Sprite Sprite
        {
            get;
            private set;
        }
        
        [field: SerializeField]
        public Color Color
        {
            get;
            private set;
        }

        [field: SerializeField]
        public Vector2 Size
        {
            get;
            private set;
        }

        [field: SerializeField]
        public int ClicksToKill
        {
            get;
            private set;
        }
    }
}