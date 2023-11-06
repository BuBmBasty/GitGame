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
            _pSm.GunController.Fire(false);
        }

        public override void UpdateLogic()
        {
            if (_pSm.FireJoystick.Direction != Vector2.zero)
            {
                _pSm.ChangeState(_pSm.PlayerGunState);
            }
        }

        public override void UpdateMovement()
        {
            if (_pSm.MovementJoy.Direction != Vector2.zero)
            {
                _currentFloat = _pSm.MovementJoy.Direction.magnitude;
                _currentSpeed = Mathf.Lerp(_pSm.walkSpeed, _pSm.runSpeed, _currentFloat);
                _pSm.ThisTransform.up = _pSm.MovementJoy.Direction;
                _pSm.moveNoneGun.Invoke(_pSm.MovementJoy.Direction*_currentSpeed,_currentFloat);
            }
            else
            {
                _pSm.Move.Invoke(0,0);
            }
        }
    }
}
