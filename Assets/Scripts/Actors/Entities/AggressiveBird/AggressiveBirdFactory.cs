using UnityEngine;

namespace Assets.Scripts
{
    class AggressiveBirdFactory : ActorFactory<AggressiveBird, AggressiveBirdConfig>
    {
        public AggressiveBirdFactory(AggressiveBirdConfig config) : base(config) { }

        public override AggressiveBird GetCreated()
        {
<<<<<<< Updated upstream
            AggressiveBird aggressiveBird = Object.Instantiate(_config.Prefab);
            Mover mover = aggressiveBird.gameObject.AddComponent<Mover>();
=======
            AggressiveBird aggressiveBird = Object.Instantiate(_config.AggressiveBird);

            aggressiveBird.gameObject.AddComponent<Mover>().Receive(_config);

>>>>>>> Stashed changes
            Disappearer disappearer = aggressiveBird.gameObject.AddComponent<Disappearer>();
            aggressiveBird.AddReaction<CollisionDetector, Quadcopter, Car>(new AggressiveBirdKillReaction());
            aggressiveBird.AddReaction<CollisionDetector, NetGuy>(new FreezeReaction());
            aggressiveBird.AddReaction<FrontDetector>(new AggressiveBirdCryReaction());
            mover.SetSelfSpeed(_config.SelfSpeed);
            disappearer.SetDisappearPoint(new Vector3(0, 0, -20));
            return aggressiveBird;
        }
    }
}
