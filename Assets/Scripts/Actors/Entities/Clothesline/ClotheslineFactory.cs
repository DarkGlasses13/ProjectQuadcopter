using UnityEngine;

namespace Assets.Scripts
{
    class ClotheslineFactory : ActorFactory<Clothesline, ClotheslineConfig>
    {
        public ClotheslineFactory(ClotheslineConfig config) : base(config) { }

        public override Clothesline GetCreated()
        {
<<<<<<< Updated upstream
            Clothesline clothesline = Object.Instantiate(_config.Prefab);
            clothesline.gameObject.AddComponent<Mover>();
            clothesline.gameObject.AddComponent<Disappearer>();
            return clothesline;
=======
            return null;
>>>>>>> Stashed changes
        }
    }
}
