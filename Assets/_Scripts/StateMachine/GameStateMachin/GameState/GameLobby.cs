using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.StateMachine.GameStateMachin.GameState
{
    public class GameLobby : BaseGameState
    {
        private GameSM _gameStateMachine;

        public GameLobby(string statename, GameSM stateMachine) : base(statename, stateMachine)
        {
            name = statename;
            _gameStateMachine = stateMachine;
        }

        public override void Enter()
        {
            Debug.Log(name);
            if (SceneManager.GetActiveScene().name != "Lobby")
                SceneManager.LoadScene("Lobby");
        }
    }
}
