using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBulletTime : BaseGameState
{
    private BaseGameStateMachine _gameStateMachine;

    public GameBulletTime(BaseGameStateMachine stateMachine) : base("GameBulletTime", stateMachine)
    {
        _gameStateMachine = stateMachine;
    }
}
