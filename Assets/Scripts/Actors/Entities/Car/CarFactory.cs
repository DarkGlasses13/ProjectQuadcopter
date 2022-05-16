using UnityEngine;

namespace Assets.Scripts
{
    class CarFactory : ActorFactory<Car, CarConfig>
    {
        private Entity _target;

        public CarFactory(CarConfig config, Quadcopter target) : base(config) => this._target = target;

        public override Car GetCreated()
        {
            Car car = Object.Instantiate(_config.Prefab);
            car.gameObject.AddComponent<Mover>().SetSelfSpeed(_config.SelfSpeed);
            car.gameObject.AddComponent<Disappearer>();

            SpecialReactionDataBase specialCollision = new SpecialReactionDataBase();
            car.AddDetector<CollisionDetector>(specialCollision);
            specialCollision.AddReaction<Quadcopter>(new CausingDamage(_target.GetComponent<Health>()));
            
            
            
            GeneralReactionDataBase generalFront = new GeneralReactionDataBase();
            car.AddDetector<FrontDetector>(generalFront).SetDetectionDistance(_config.DetectionDistance);
            generalFront.AddGeneralReaction(new CryReaction());

            return car;
        }
    }
}
