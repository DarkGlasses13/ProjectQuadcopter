using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class NetEquiper : ConfigReceiver<NetGuyConfig>
    {
        private NetPoint _netPoint;
        private List<Net> _nets = new();
        private Net _equipedNet;

        public Net EquipedNet
        {
            get => _equipedNet;

            private set 
            {
                _equipedNet?.gameObject.SetActive(false);
                value.gameObject.SetActive(true);
                _equipedNet = value;
            }
        }

        public override void Receive(NetGuyConfig config)
        {
            base.Receive(config);
            _netPoint = GetComponentInChildren<NetPoint>();

            for (int i = 0; i < _config.NetPrefabsCount; i++)
            {
                Net net = Instantiate(_config.Net, _netPoint.transform);
                net.AddReaction<CollisionDetector, Quadcopter>(new NetCatchingReaction(config, GetComponentInParent<NetGuy>()));
                _nets.Add(net);
            }
        }   

        public void Equip() => EquipedNet = _nets[Random.Range(0, _nets.Count)];
    }
}
