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
            _pSm.Move.Invoke(_pSm.movementJoy.Direction.x*_currentSpeed,_pSm.movementJoy.Direction.y*_currentSpeed);
         }
         else
         {
            _pSm.Move.Invoke(0,0);
         }
      }
   }
}
