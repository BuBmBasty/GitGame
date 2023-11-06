using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLobby : BaseGameState
{
    private BaseGameStateMachine _gameStateMachine;

    public GameLobby(BaseGameStateMachine stateMachine) : base("GameLobby", stateMachine)
    {
        _gameStateMachine = stateMachine;
    }

    public override void Enter()
    {
        Debug.Log("GameLobby");
        if (SceneManager.GetActiveScene().name != "Lobby")
            SceneManager.LoadScene("Lobby");
    }
}
