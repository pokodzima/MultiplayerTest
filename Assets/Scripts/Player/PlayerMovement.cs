using Fusion;
using InputHandlers;
using UnityEngine;
using Services;

namespace Player
{
    public class PlayerMovement : SimulationBehaviour
    {
        [SerializeField] private float _moveSpeed;
        private Vector2 _move;
        private JoystickController _joystickController;

        void Start()
        {
            _joystickController = ServiceLocator.Resolve<JoystickController>();
        }
        public override void FixedUpdateNetwork()
        {
            if (HasStateAuthority == false)
            {
                return;
            }

            _move.x = _joystickController.GetHorizontalInput();
            _move.y = _joystickController.GetVerticalInput();

            transform.Translate(_move * (Runner.DeltaTime * _moveSpeed));
        }
    }
}
