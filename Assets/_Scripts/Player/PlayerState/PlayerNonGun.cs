using _Scripts.StateMachine;
using UnityEngine;

namespace _Scripts.Player.PlayerState
{
    public class PlayerNonGun : BaseState
    {
        private PlayerSM _pSm;
        private float _currentSpeed, _currentFloat;
        public PlayerNonGun(PlayerSM stateMachine) : base("BaseNonGun", stateMachine)
        {
            _pSm = (PlayerSM)stateMachine;
        }

   
        public override void Enter()
        {
            _pSm.animatorController.SetFireState(false);
            _pSm.gunController.Fire(false);
        }

        public override void UpdateLogic()
        {
            if (_pSm.fireJoystick.Direction != Vector2.zero)
            {
                _pSm.ChangeState(_pSm.playerGunState);
            }
        }

        public override void UpdateMovement()
        {
            if (_pSm.movementJoy.Direction != Vector2.zero)
            {
                _currentFloat = _pSm.movementJoy.Direction.magnitude;
                _currentSpeed = Mathf.Lerp(_pSm.walkSpeed, _pSm.runSpeed, _currentFloat);
                _pSm.thisTransform.up = _pSm.movementJoy.Direction;
                _pSm.animatorController.SetMovement(_currentFloat);
                _pSm.character2DController.Move(_pSm.movementJoy.Direction*_currentSpeed);
            }
            else
            {
                _pSm.character2DController.Move(Vector2.zero);
                _pSm.animatorController.SetMovement(0);
            }
        }
    }
}
