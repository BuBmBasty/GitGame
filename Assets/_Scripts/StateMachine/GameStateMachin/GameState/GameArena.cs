using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameArena : BaseGameState
{
    private BaseGameStateMachine _gameStateMachine;

    public GameArena(BaseGameStateMachine stateMachine) : base("GameArena", stateMachine)
    {
        _gameStateMachine = stateMachine;
    }

    public override void Enter()
    {
        Debug.Log(("GameArena"));
        if (SceneManager.GetActiveScene().name != "GameArena")
            SceneManager.LoadScene("GameArena");
    }
}
