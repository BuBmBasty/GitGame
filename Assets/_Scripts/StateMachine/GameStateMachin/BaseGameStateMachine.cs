using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGameStateMachine : MonoBehaviour
{
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
