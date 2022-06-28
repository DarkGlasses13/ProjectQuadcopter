using UnityEngine;

namespace Assets.Scripts
{
    class NetGuyFactory : ActorFactory<NetGuy, NetGuyConfig>
    {
        public NetGuyFactory(NetGuyConfig config) : base(config) { }

        public override NetGuy GetCreated()
        {
<<<<<<< Updated upstream
            NetGuy netGuy = Object.Instantiate(_config.Prefab);
            netGuy.gameObject.AddComponent<Mover>();
            netGuy.gameObject.AddComponent<Disappearer>().SetDisappearPoint(new Vector3(0, 0, -20));
            netGuy.AddReaction<CollisionDetector, Quadcopter, AggressiveBird>(new NetCatchReaction());
            RadiusableDetector radiusableDetector = netGuy.AddReaction<RadiusableDetector, Quadcopter>(new LeanOutWindowReaction(netGuy));
            radiusableDetector.SetRadius(_config.DetectionRadius, _config.SemiMajorAxis);
=======
            NetGuy netGuy = Object.Instantiate(_config.NetGuy);
            Animator animator =  netGuy.GetComponent<Animator>();
            animator.keepAnimatorControllerStateOnDisable = true;

            netGuy.gameObject.AddComponent<Mover>().Receive(_config);

            netGuy.gameObject
                .AddComponent<Disappearer>()
                .SetDisappearPoint(_wayMatrix.DisappearPoint)
                .OnDisappear += () => animator.SetFloat(AnimationService.Parameters.ShoveSide, 0);

            netGuy
                .AddReaction<EllipseDetector, Quadcopter>(new ShoveOutReaction(_config, netGuy))
                .Receive(_config);

            netGuy.gameObject
                .AddComponent<NetEquiper>()
                .Receive(_config);

>>>>>>> Stashed changes
            return netGuy;
        }
    }
}
