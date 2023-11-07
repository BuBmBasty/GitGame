using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.StateMachine.GameStateMachin.GameState
{
    public class GameArena : BaseGameState
    {
        public GameArena(GameSM stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            Debug.Log((Name));
            if (SceneManager.GetActiveScene().name != "GameArena")
                SceneManager.LoadScene("GameArena");
        }
    }
}
