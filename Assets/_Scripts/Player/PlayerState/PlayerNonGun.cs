using _Scripts.StateMachine;
using UnityEngine;

namespace _Scripts.Player.PlayerState
{
    public class PlayerNonGun : BaseState
    {
        private PlayerSm _pSm;
        private float _currentSpeed, _currentFloat;
        public PlayerNonGun(PlayerSm stateMachine) : base("BaseNonGun", stateMachine)
        {
            _pSm = (PlayerSm)stateMachine;
        }

   
        public override void Enter()
        {
            _pSm.Fire.Invoke(false);
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
                _pSm.MoveNoneGun.Invoke(_pSm.movementJoy.Direction*_currentSpeed,_currentFloat);
            }
            else
            {
                _pSm.Move.Invoke(0,0);
            }
        }
    }
}
