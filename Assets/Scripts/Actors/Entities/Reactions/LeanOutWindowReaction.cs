using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts
{
    public class LeanOutWindowReaction : IReaction
    {
        private WindowLeanOuter _windowLeanOuter;
        private float _speed;

        public LeanOutWindowReaction(WindowLeanOuter windowLeanOuter, float speed)
        {
            _windowLeanOuter = windowLeanOuter;
            _speed = speed;
        }

        public void React()
        {
            _windowLeanOuter.LeanOutWindow(_speed);  
        } 
    }
}

