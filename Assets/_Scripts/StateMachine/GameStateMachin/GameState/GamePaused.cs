using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePaused : BaseGameState
{
    private BaseGameStateMachine _gameStateMachine;
    public GamePaused(BaseGameStateMachine stateMachine) : base("GamePaused", stateMachine)
    {
        _gameStateMachine = stateMachine;
    }
}
