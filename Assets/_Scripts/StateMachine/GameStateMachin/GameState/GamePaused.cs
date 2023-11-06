using System.Collections;
using System.Collections.Generic;
using _Scripts.StateMachine.GameStateMachin;
using UnityEngine;

public class GamePaused : BaseGameState
{
    private GameSM _gameStateMachine;
    public GamePaused(string statename, GameSM stateMachine) : base(statename, stateMachine)
    {
        name = statename;
        _gameStateMachine = stateMachine;
    }
}
