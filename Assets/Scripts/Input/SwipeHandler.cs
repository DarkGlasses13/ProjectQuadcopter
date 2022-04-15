using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

namespace Assets.Scripts
{
    public class SwipeHandler : MonoBehaviour
    {
        public static event Action<int, int> OnSwipe;

        [SerializeField] [Range(0, 1)] private float _directionThreshold;
        [SerializeField] [Range(0, 300)] private int _deadZone;

        public Vector2 StartContact { get; private set; }
        public Vector2 EndContact { get; private set; }
        
        private void OnEnable()
        {
            EnhancedTouchSupport.Enable();
            Touch.onFingerDown += callbackContext => StartSwipe();
            Touch.onFingerUp += callbackContext => EndSwipe();
        }

        private void StartSwipe() => StartContact = Touch.activeFingers[0].currentTouch.startScreenPosition;

        private void EndSwipe()
        {
            EndContact = Touch.activeFingers[0].currentTouch.screenPosition;
            Vector2 swipeDirection = (EndContact - StartContact);

            if (swipeDirection.magnitude >= _deadZone)
            {
                CalculateDirection(swipeDirection.normalized, out int x, out int y);
                OnSwipe?.Invoke(x, y);
            }
        }

        private void CalculateDirection(Vector2 swipeDirection, out int x, out int y)
        {
            x = 0;
            y = 0;

            if (swipeDirection.x > 0.5f)
            {
                x = 1;
            }
            else if (swipeDirection.x < -0.5f)
            {
                x = -1;
            }
               

            if (swipeDirection.y > 0.5f)
            {
                y = 1;
            }
            else if (swipeDirection.y < -0.5f)
            {
                y = -1;
            }
        }

        private SwipeDirection DeterminateDirection(Vector2 swipeDirection)
        {
            if (Vector2.Dot(Vector2.left, swipeDirection) > _directionThreshold) return SwipeDirection.Left;

            if (Vector2.Dot(Vector2.right, swipeDirection) > _directionThreshold) return SwipeDirection.Right;

            if (Vector2.Dot(Vector2.up, swipeDirection) > _directionThreshold) return SwipeDirection.Up;

            if (Vector2.Dot(Vector2.down, swipeDirection) > _directionThreshold) return SwipeDirection.Down;

            return SwipeDirection.Zero;
        }

        private void OnDisable() => EnhancedTouchSupport.Disable();
    }

    public enum SwipeDirection
    {
                 Up,

        Left,   Zero,  Right,

                Down
    }
}