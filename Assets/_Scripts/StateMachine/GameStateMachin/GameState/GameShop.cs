using System.Collections;
using System.Collections.Generic;
using _Scripts.StateMachine.GameStateMachin;
using UnityEngine;

public class GameShop : BaseGameState
{
    private GameSM _gameStateMachine;
    public GameShop(string statename, GameSM stateMachine) : base(statename, stateMachine)
    {
        name = statename;
        _gameStateMachine = stateMachine;
    }
}
