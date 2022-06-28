using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Car", fileName = "New Car Config")]
<<<<<<< Updated upstream
    public class CarConfig : MultiplePrefabActorConfig<Car>
=======
    public class CarConfig : MultiplePrefabActorConfig, ICanMove, ICanDetect
>>>>>>> Stashed changes
    {
        [SerializeField] private Car[] _carPrefabs;
        [SerializeField] [Range(1, 100)] private float _selfSpeed;
        [SerializeField] [Range(1, 100)] private float _detectionDistance;

<<<<<<< Updated upstream
        public float SelfSpeed { get => _selfSpeed; }
        public float DetectionDistance { get => _detectionDistance; }
=======
        private int _prefabIndex;

        public Car Car => GetPrefab(_carPrefabs, ref _prefabIndex);
        public float SelfSpeed => _selfSpeed;
        public float DetectionDistance => _detectionDistance;
>>>>>>> Stashed changes
    }
}
