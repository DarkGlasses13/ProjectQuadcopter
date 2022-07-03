using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameStartup : MonoBehaviour
    {
        [SerializeField] private City _city;

        private ChunkGenerator _chunkGenerator;
        private EntitySpawner _entitySpawner;
        private Button _tapToStartButton;
        private Quadcopter _quadcopter;
        private GameStopper _gameStopper;

        private void Awake()
        {
            _entitySpawner = GetComponentInChildren<EntitySpawner>();
            _chunkGenerator = GetComponentInChildren<ChunkGenerator>();
            _gameStopper = GetComponentInChildren<GameStopper>();
            _tapToStartButton = FindObjectOfType<TapToStart>().GetComponent<Button>();
        }

        private void Start()
        {
            Container chunkContainer = ContainerService.GetCreatedContainer("Chunks", _city.transform);
            Container entityContainer = ContainerService.GetCreatedContainer("Entities", _city.transform);
            _chunkGenerator.EnableChunks(chunkContainer);
            _entitySpawner.EnablePlayerCamera(entityContainer);
            _quadcopter = _entitySpawner.EnableQuadcopter(entityContainer);
            _entitySpawner.EnableCarTraffic(entityContainer);
            //_entitySpawner.EnableAggressiveBirds(entityContainer);
            //_entitySpawner.EnableNetGuys(entityContainer, _chunkGenerator);
            //_entitySpawner.EnableBatteries(entityContainer);
            _gameStopper.Stop();
            _tapToStartButton.onClick.AddListener(Startup);
        }

        private void Startup()
        {
            _quadcopter.gameObject.SetActive(true);
            new QuadcopterNextReaction(_quadcopter).React();
            _gameStopper.Play();
            _tapToStartButton.gameObject.SetActive(false);
            _quadcopter.GetComponent<SwipeController>().enabled = true;
            _quadcopter.GetComponent<Charger>().Recharge();
        }
    }
}