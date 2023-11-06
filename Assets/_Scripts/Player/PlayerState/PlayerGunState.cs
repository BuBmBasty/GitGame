using _Scripts.StateMachine;
using UnityEngine;

namespace _Scripts.Player.PlayerState
{
   public class PlayerGunState : BaseState
   {
      private PlayerSm _pSm;
      private Vector3 _movementVector;
      private float _currentSpeed, _currentFloat;
      public PlayerGunState(PlayerSm stateMachine) : base("BaseGunState", stateMachine)
      {
         _pSm = (PlayerSm)stateMachine;
      }
      public override void Enter()
      {
         _pSm.Fire.Invoke(true);
         _pSm.GunController.Fire(true);
      }

      public override void UpdateLogic()
      {
         if (_pSm.FireJoystick.Direction == Vector2.zero)
         {
            _pSm.ChangeState(_pSm.PlayerNonGun);
         }
      }

      public override void UpdatePhysics()
      {
     
      }

      public override void UpdateMovement()
      {
         _pSm.ThisTransform.up = _pSm.FireJoystick.Direction;
      
         if (_pSm.MovementJoy.Direction != Vector2.zero)
         {
            _currentFloat = _pSm.MovementJoy.Direction.magnitude;
            _currentSpeed = Mathf.Lerp(_pSm.walkSpeed, _pSm.runSpeed, _currentFloat);
            _movementVector = _pSm.ThisTransform.TransformVector(_pSm.MovementJoy.Direction);
            _pSm.Move.Invoke(_pSm.MovementJoy.Direction.x*_currentSpeed,_pSm.MovementJoy.Direction.y*_currentSpeed);
         }
         else
         {
            _pSm.Move.Invoke(0,0);
         }
      }
   }
}
