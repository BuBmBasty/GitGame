using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.StateMachine.GameStateMachin.GameState
{
    public class GameArena : BaseGameState
    {
        private GameSM _gameStateMachine;

        public GameArena(string statename, GameSM stateMachine) : base(statename, stateMachine)
        {
            name = statename;
            _gameStateMachine = stateMachine;
        }

        public override void Enter()
        {
            Debug.Log((name));
            if (SceneManager.GetActiveScene().name != "GameArena")
                SceneManager.LoadScene("GameArena");
        }
    }
}
