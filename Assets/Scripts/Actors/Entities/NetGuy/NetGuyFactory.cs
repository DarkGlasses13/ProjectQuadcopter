using UnityEngine;

namespace Assets.Scripts
{
    class NetGuyFactory : ActorFactory<NetGuy, NetGuyConfig>
    {
        private Entity _target;

        public NetGuyFactory(NetGuyConfig config, Entity target) : base(config) => _target = target;

        public override NetGuy GetCreated()
        {
            NetGuy netGuy = Object.Instantiate(_config.Prefab);
            WindowLeanOuter windowLeanOuter = netGuy.gameObject.AddComponent<WindowLeanOuter>();
            netGuy.gameObject.AddComponent<Mover>();
            netGuy.gameObject.AddComponent<Disappearer>().SetDisappearPoint(_target.transform.position + Vector3.back);
            
            SpecialReactionDataBase specialCollision = new SpecialReactionDataBase();
            netGuy.AddDetector<CollisionDetector>(specialCollision);
            specialCollision.AddReaction<Quadcopter>(new CausingDamage(_target.GetComponent<Health>()));

            // SpecialReaction specialRadiusable = new GeneralReaction();
            // RadiusableDetector radiusDetector = netGuy.AddDetector<RadiusableDetector>(specialRadiusable);
            // specialRadiusable.AddReaction<Quadcopter>(new LeanOutWindowReaction(windowLeanOuter,_config.SpeedDeparture));

            // radiusDetector.SetRadius(_config.RangeDetector);
            // radiusDetector.SetTarget(_target);
            return netGuy;
        }
    }
}
 