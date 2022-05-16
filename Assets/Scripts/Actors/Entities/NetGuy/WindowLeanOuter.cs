using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class WindowLeanOuter : MonoBehaviour
    {
        private Animator _animator;
        private float _condition = 0;

        private void Awake() => _animator = GetComponent<Animator>();

        public void LeanOutWindow(float speed)
        {
            _condition = 0;
            SetDirectionMove(Mathf.Clamp(transform.position.x, -1, 1), speed);
        }
        
        private void SetDirectionMove(float to,float value)
        {
            float numberSign = Mathf.Clamp(to, -1, 1);
            StartCoroutine(Сounter(to, value, numberSign));
        }
        
        IEnumerator Сounter(float to,float value,float numberSign)
        {
            if (_condition < to * numberSign) 
            {
                _condition += value;
                _animator.SetFloat(AnimationService.Parameters.LeanOutingSide, -_condition * numberSign);
                yield return new WaitForFixedUpdate();
                StartCoroutine(Сounter(to, value,numberSign));
            }
        }
        
        private void OnDisable() => _animator.SetFloat(AnimationService.Parameters.LeanOutingSide, 0);
    }
}