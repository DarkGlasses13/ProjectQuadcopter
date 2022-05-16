using UnityEngine;

namespace Assets.Scripts
{
    class AggressiveBirdFactory : ActorFactory<AggressiveBird, AggressiveBirdConfig>
    {
        private Entity _target;

        public AggressiveBirdFactory(AggressiveBirdConfig config, Entity target) : base(config) => _target = target;

        public override AggressiveBird GetCreated()
        {
            AggressiveBird aggressiveBird = Object.Instantiate(_config.Prefab);
            aggressiveBird.gameObject.AddComponent<Mover>().SetSelfSpeed(_config.SelfSpeed);
            aggressiveBird.gameObject.AddComponent<Disappearer>().SetDisappearPoint(new Vector3(0, 0 , -20));
           
            SpecialReactionDataBase specialCollision = new SpecialReactionDataBase();
            aggressiveBird.AddDetector<CollisionDetector>(specialCollision);
            specialCollision.AddReaction<Quadcopter>(new CausingDamage(_target.GetComponent<Health>()));

            GeneralReactionDataBase generalFront = new GeneralReactionDataBase();
            aggressiveBird.AddDetector<FrontDetector>(generalFront).SetDetectionDistance(_config.DetectionDistance);
            generalFront.AddGeneralReaction(new CryReaction());

            return aggressiveBird;
        }
    }
}
