using _Scripts.StateMachine.GameStateMachin;
using UnityEngine;

public class BaseGameStateMachine : MonoBehaviour
{
    public BaseGameState currentState=>_currentState;
    private BaseGameState _currentState;
    public void ChangeState(BaseGameState newState)
    {
        if (_currentState!=null)_currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }
    
    public void FixedUpdate()
    {
        if (_currentState != null)
        {
            _currentState.UpdateLogic();
        }
    }
    protected virtual BaseGameState GetInitialState()
    {
        return null;
    }
}
