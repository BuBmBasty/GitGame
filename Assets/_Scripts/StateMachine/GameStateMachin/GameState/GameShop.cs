using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameShop : BaseGameState
{
    private BaseGameStateMachine _gameStateMachine;
    public GameShop(BaseGameStateMachine stateMachine) : base("GameShop", stateMachine)
    {
        _gameStateMachine = stateMachine;
    }
}
