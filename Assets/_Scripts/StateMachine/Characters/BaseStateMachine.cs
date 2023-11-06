
using UnityEngine;

namespace _Scripts.StateMachine
{
    public class BaseStateMachine : MonoBehaviour
    {
        private BaseState _currentState;
        private void Start()
        {
            _currentState = GetInitialState();
            if (_currentState != null) _currentState.Enter();
        }
      
        public void Update()
        {
            if (_currentState != null)
            {
                _currentState.UpdateLogic();
            }
        } 
        
        public void LateUpdate()
        {
            if (_currentState != null)
            {
                _currentState.UpdatePhysics();
            }
        }

        public void FixedUpdate()
        {
            if (_currentState != null)
            {
                _currentState.UpdateMovement();
            }
        }

        public void ChangeState(BaseState newState)
        {
            if (_currentState!=null)_currentState.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        protected virtual BaseState GetInitialState()
        {
            return null;
        }
    }
}
