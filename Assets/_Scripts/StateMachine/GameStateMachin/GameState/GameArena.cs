using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.StateMachine.GameStateMachin.GameState
{
    public class GameArena : BaseGameState
    {
        [Header("OSTMusic")] 
        [SerializeField] private AudioClip _start;
        [SerializeField] private AudioClip _loop;

        private bool _startingGame;
        public GameArena(GameSm stateMachine) : base(stateMachine)
        {
        }

        private void OnEnable()
        {
            if (!_startingGame)
            {
                _startingGame = true;
                OSTController.Instance.newOstMusic.Invoke(_start,_loop);
            }
        }

        public override void Enter()
        {
            Debug.Log((Name));
            if (SceneManager.GetActiveScene().name != "GameArena")
            {
                OSTController.Instance.newOstMusic.Invoke(_start,_loop);
                SceneManager.LoadScene("GameArena");
            }
        }
    }
}
