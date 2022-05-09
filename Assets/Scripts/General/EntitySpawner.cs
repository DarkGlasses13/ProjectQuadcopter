﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class EntitySpawner : MonoBehaviour
    {
        private WayMatrix _wayMatrix = new WayMatrix();
        private Dictionary<Type, IPool> _pools = new Dictionary<Type, IPool>();

        [Header("Configurations")]
        [SerializeField] private QuadcopterConfig _quadcopterConfig;
        [SerializeField] private PlayerCameraConfig _playerCameraConfig;
        [SerializeField] private AggressiveBirdConfig _aggressiveBirdConfig;
        [SerializeField] private CarConfig _carConfig;
        [SerializeField] private ClotheslineConfig _clotheslineConfig;
        [SerializeField] private NetGuyConfig _netGuyConfig;

        [Header("SpawnDensity")]
        [SerializeField][Range(0, 100)] private int _aggressiveBirdDensity;
        [SerializeField][Range(0, 100)] private int _carDensity;
        [SerializeField][Range(0, 100)] private int _clothesLineDensity;
        [SerializeField][Range(0, 100)] private int _netGuyDensity;

        [Header("BirdRows")]
        [SerializeField][Range(1, 4)] private int _birdsRows;

        public int AggressiveBirdDensity => _aggressiveBirdDensity;
        public int CarDensity => _carDensity;
        public int ClotheslineDensity => _clothesLineDensity;
        public int NetGuyDensity => _netGuyDensity;

        public Container EntitiesContainer { get; private set; }

        public void Init(City city)
        {
            EntitiesContainer = ContainerService.GetCreatedContainer("Entities", city.transform, Vector3.zero);

            Quadcopter quadcopter = GetCreatedEntity(new QuadcopterFactory(_quadcopterConfig, EntitiesContainer));
            GetCreatedEntity(new PlayerCameraFactory(_playerCameraConfig, EntitiesContainer, _wayMatrix.GetPosition(MatrixPosition.Center)));

            _pools[typeof(AggressiveBird)] = new Pool<AggressiveBird>(new AggressiveBirdFactory(_aggressiveBirdConfig, quadcopter), EntitiesContainer, 10);
            _pools[typeof(Car)] = new Pool<Car>(new CarFactory(_carConfig, quadcopter), EntitiesContainer, 10);
            _pools[typeof(Clothesline)] = new Pool<Clothesline>(new ClotheslineFactory(_clotheslineConfig, quadcopter), EntitiesContainer, 10);
            _pools[typeof(NetGuy)] = new Pool<NetGuy>(new NetGuyFactory(_netGuyConfig, quadcopter), EntitiesContainer, 10);
        }

        public void EnableCarTraffic()
        {
            for (int i = 0; i < _wayMatrix.Width; i++)
            {
                StartCoroutine(CarSpawnRoutine(i));
            }
        }

        public void EnableAggressiveBirds()
        {
            for (int row = _birdsRows - 1; row >= 0; row--)
            {

                for (int i = 0; i < _wayMatrix.Width; i++)
                {
                    StartCoroutine(AggressiveBirdSpawnRoutine(i, row));
                }
            }
        }

        IEnumerator CarSpawnRoutine(int line)
        {
            float horizon = 200f;
            float startSpeed = SpeedService.Speed;

            while (true)
            {
                Vector3 position = _wayMatrix.GetPositionByArrayCoordinates(new Vector2Int(line, _wayMatrix.Height - 1));

                if (_carDensity > Random.Range(0, 100))
                {
                    GetPool<Car>().Get(position + Vector3.forward * horizon);
                }

                yield return new WaitForSeconds(Random.Range(0.15f * startSpeed / SpeedService.Speed, 0.5f * startSpeed / SpeedService.Speed));
            }
        }

        private IEnumerator AggressiveBirdSpawnRoutine(int line, int row)
        {
            float horizon = 200f;
            float startSpeed = SpeedService.Speed;

            while (true)
            {
                Vector3 position = _wayMatrix.GetPositionByArrayCoordinates(new Vector2Int(line, row));

                if (_aggressiveBirdDensity > Random.Range(0, 100))
                {
                    GetPool<AggressiveBird>().Get(position + Vector3.forward * horizon);
                }

                yield return new WaitForSeconds(Random.Range(0.15f * startSpeed / SpeedService.Speed, 0.5f * startSpeed / SpeedService.Speed));
            }
        }

        public Pool<T> GetPool<T>() where T : Actor => _pools[typeof(T)] as Pool<T>;

        private E GetCreatedEntity<E>(IFactory<E> entityFactory) where E : Entity => entityFactory.GetCreated();

        private void OnDisable() => StopAllCoroutines();
    }
}
