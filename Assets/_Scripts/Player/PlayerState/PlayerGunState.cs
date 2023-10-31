using _Scripts.StateMachine;
using UnityEngine;

namespace _Scripts.Player.PlayerState
{
   public class PlayerGunState : BaseState
   {
      private PlayerSM _pSm;
      private Vector3 _movementVector;
      private float _currentSpeed, _currentFloat;
      public PlayerGunState(PlayerSM stateMachine) : base("BaseGunState", stateMachine)
      {
         _pSm = (PlayerSM)stateMachine;
      }
      public override void Enter()
      {
         _pSm.animatorController.SetFireState(true);
         _pSm.gunController.Fire(true);
      }

      public override void UpdateLogic()
      {
         if (_pSm.fireJoystick.Direction == Vector2.zero)
         {
            _pSm.ChangeState(_pSm.playerNonGun);
         }
      }

      public override void UpdatePhysics()
      {
     
      }

      public override void UpdateMovement()
      {
         _pSm.thisTransform.up = _pSm.fireJoystick.Direction;
      
         if (_pSm.movementJoy.Direction != Vector2.zero)
         {
            _currentFloat = _pSm.movementJoy.Direction.magnitude;
            _currentSpeed = Mathf.Lerp(_pSm.walkSpeed, _pSm.runSpeed, _currentFloat);
            _movementVector = _pSm.thisTransform.TransformVector(_pSm.movementJoy.Direction);
            _pSm.character2DController.Move(_pSm.movementJoy.Direction*_currentSpeed);
            _pSm.animatorController.SetMovement(_movementVector.x,_movementVector.y);
         }
         else
         {
            _pSm.character2DController.Move(Vector2.zero);
            _pSm.animatorController.SetMovement(0,0);
         }
      }
   }
}
