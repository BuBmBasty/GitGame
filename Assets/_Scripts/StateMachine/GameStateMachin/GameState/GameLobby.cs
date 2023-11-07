using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.StateMachine.GameStateMachin.GameState
{
    public class GameLobby : BaseGameState
    {
        public GameLobby(GameSM stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            Debug.Log(Name);
            if (SceneManager.GetActiveScene().name != "Lobby")
                SceneManager.LoadScene("Lobby");
        }
    }
}
