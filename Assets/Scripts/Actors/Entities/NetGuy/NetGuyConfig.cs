using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Net", fileName = "New Net Config")]
<<<<<<< Updated upstream
    public class NetGuyConfig : MultiplePrefabActorConfig<NetGuy>
    {
        [SerializeField][Range(1, 100)] private float _detectionRadius;
        [SerializeField][Range(1, 10)] private float _semiMajorAxis;

        public float DetectionRadius => _detectionRadius;
        public float SemiMajorAxis => _semiMajorAxis;
        
=======
    public class NetGuyConfig : MultiplePrefabActorConfig, ICanMove, ICanDetect
    {
        [SerializeField] private NetGuy[] _netGuyPrefabs;
        [SerializeField] private Net[] _netPrefabs;
        [SerializeField][Range(1, 100)] private float _detectionDistance;
        [SerializeField][Range(0, 10)] private float _shoveOutSpeed;
        [SerializeField][Range(0, 10)] private float _shoveInSpeed;

        private int _netGuyPrefabsIndex;
        private int _netPrefabsIndex;

        public NetGuy NetGuy => GetPrefab(_netGuyPrefabs, ref _netGuyPrefabsIndex);
        public Net Net => GetPrefab(_netPrefabs, ref _netPrefabsIndex);
        public float SelfSpeed => 0;
        public float DetectionDistance => _detectionDistance;
        public float ShoveOutSpeed => _shoveOutSpeed;
        public float ShoveInSpeed => _shoveInSpeed;
        public int NetPrefabsCount => _netPrefabs.Length;
>>>>>>> Stashed changes
    }
}
