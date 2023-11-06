using System.Collections;
using UnityEngine;

namespace _Scripts.StateMachine.GameStateMachin.GameState
{
    public class GameBulletTime : BaseGameState
    {
        [SerializeField] private float _bulletTimer, _timerCount;
        private GameSM _gameStateMachine;
        

        public GameBulletTime(string statename, GameSM stateMachine) : base(statename, stateMachine)
        {
            name = statename;
            _gameStateMachine = stateMachine;
        }

        public override void Enter()
        {
            Time.timeScale = 1 / _timerCount;
            StartCoroutine(ReturnTime());
        }

        IEnumerator ReturnTime()
        {
            yield return new WaitForSeconds(_bulletTimer);
            Time.timeScale = 1;
            _gameStateMachine.changeStateWithNaming.Invoke("GameArena");
        }
    }
}
