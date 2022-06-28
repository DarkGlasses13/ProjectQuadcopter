using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class ShoveOutReaction : Reaction
    {
        private NetGuyConfig _config;
        private NetGuy _netGuy;
        private Animator _animator;

        public ShoveOutReaction(NetGuyConfig config, NetGuy netGuy)
        {
            _config = config;
            _netGuy = netGuy;
            _animator = netGuy.GetComponent<Animator>();
        }

        private IEnumerator ShoveOut()
        {
            float currentSide = 0;
            float targetSide = Mathf.Clamp(_netGuy.transform.position.x, -1, 1);
            Debug.Log("ShoveOut");

            while (Mathf.Approximately(currentSide, targetSide))
            {
                Debug.Log("ShoveOut");
                currentSide = Mathf.Lerp(currentSide, targetSide, _config.ShoveOutSpeed * Time.deltaTime);
                _animator.SetFloat(AnimationService.Parameters.ShoveSide, currentSide);
                yield return null;
            }

            yield break;
        }

        public override void React() => _netGuy.StartCoroutine(ShoveOut());
    }
}
