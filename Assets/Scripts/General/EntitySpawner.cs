﻿using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Scripts
{
    public class EntitySpawner : MonoBehaviour
    {
        [Header("Configurations")]
        [SerializeField] private QuadcopterConfig _quadcopterConfig;
        [SerializeField] private PlayerCameraConfig _playerCameraConfig;
        [SerializeField] private AggressiveBirdConfig _aggressiveBurdConfig;
        [SerializeField] private CarConfig _carConfig;
        [SerializeField] private ClotheslineConfig _clotheslineConfig;
        [FormerlySerializedAs("_netConfig")] [SerializeField] private NetGuyConfig netGuyConfig;

        public Container EntitieContainer { get; private set; }
        public Pool<AggressiveBird> AggressiveBirdPool { get; private set; }
        public Pool<Car> CarPool { get; private set; }
        public Pool<Clothesline> ClotheslinePool { get; private set; }
        public Pool<NetGuy> NetPool { get; private set; }

        public void Init(City city, WayMatrix wayMatrix)
        {
            EntitieContainer = ContainerService.GetCreatedContainer("Entities", city.transform, Vector3.zero);
            Quadcopter quadcopter = GetCreatedEntity(new QuadcopterFactory(_quadcopterConfig, EntitieContainer, wayMatrix));
            GetCreatedEntity(new PlayerCameraFactory(_playerCameraConfig, EntitieContainer, wayMatrix.Center));
            AggressiveBirdPool = new Pool<AggressiveBird>(new AggressiveBirdFactory(_aggressiveBurdConfig, quadcopter), EntitieContainer, 10);
            CarPool = new Pool<Car>(new CarFactory(_carConfig, quadcopter), EntitieContainer, 10);
            ClotheslinePool = new Pool<Clothesline>(new ClotheslineFactory(_clotheslineConfig, quadcopter), EntitieContainer, 10);
            NetPool = new Pool<NetGuy>(new NetGuyFactory(netGuyConfig, quadcopter), EntitieContainer, 10);
        }

        private E GetCreatedEntity<E>(IFactory<E> entityFactory) where E : Entity => entityFactory.GetCreated();
    }
}
