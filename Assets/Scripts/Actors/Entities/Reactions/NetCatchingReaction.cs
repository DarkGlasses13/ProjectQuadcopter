using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class NetCatchingReaction : Reaction
    {
        private NetGuyConfig _config;
        private NetGuy _owner;
        private Animator _animator;
        private float _speedFactor = 0.01f;

        public NetCatchingReaction(NetGuyConfig config, NetGuy owner) 
        {
            _config = config;
            _owner = owner;
            _animator = _owner.GetComponent<Animator>();
        }

        public override void React()
        {
            _owner.StartCoroutine(ShoveIn());
        }

        private IEnumerator ShoveIn()
        {
            float currentSide = Mathf.Clamp(_owner.transform.position.x, -1, 1);
            float targetSide = 0;

            while (currentSide != targetSide)
            {
                currentSide = Mathf.Lerp(currentSide, targetSide, _config.ShoveInSpeed * _speedFactor);
                _animator.SetFloat(AnimationService.Parameters.ShoveSide, currentSide);
                yield return null;
            }

            yield break;
        }
    }
}
