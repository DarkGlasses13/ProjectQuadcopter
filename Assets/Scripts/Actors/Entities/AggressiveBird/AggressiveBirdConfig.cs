using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Aggressive Bird", fileName = "New Aggressive Bird Config")]
<<<<<<< Updated upstream
    public class AggressiveBirdConfig : MultiplePrefabActorConfig<AggressiveBird>
=======
    public class AggressiveBirdConfig : MultiplePrefabActorConfig, ICanMove, ICanDetect
>>>>>>> Stashed changes
    {
       [SerializeField] private AggressiveBird[] _prefabs;
       [SerializeField] [Range(1, 100)] private float _selfSpeed;
       [SerializeField] [Range(1, 100)] private float _detectionDistance;

       private int _prefabIndex;

       public AggressiveBird AggressiveBird => GetPrefab(_prefabs, ref _prefabIndex);
       public float SelfSpeed { get => _selfSpeed; }
       public float DetectionDistance { get => _detectionDistance; }
    }
}
