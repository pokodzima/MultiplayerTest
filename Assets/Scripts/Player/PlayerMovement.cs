using Fusion;
using InputHandlers;
using UnityEngine;
using Services;

namespace Player
{
    public class PlayerMovement : SimulationBehaviour
    {
        [SerializeField] private float _moveSpeed;
        private Vector2 _movement;
        private Vector2 _input;
        private float _angle;
        private JoystickController _joystickController;

        void Start()
        {
            _joystickController = ServiceLocator.Resolve<JoystickController>();
        }
        public override void FixedUpdateNetwork()
        {
            if (!HasStateAuthority)
            {
                return;
            }

            _input.x = _joystickController.GetHorizontalInput();
            _input.y = _joystickController.GetVerticalInput();

            if (_input.sqrMagnitude != 0)
            {
                _angle = Mathf.Atan2(_input.y, _input.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
            }

            _movement = transform.right * _input.x + -transform.up * _input.y;
            _movement *= (Runner.DeltaTime * _moveSpeed);
            transform.Translate(_movement);
        }
    }
}
