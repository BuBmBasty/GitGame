using System.Collections;
using UnityEngine;

namespace _Scripts.StateMachine.GameStateMachin.GameState
{
    public class GameBulletTime : BaseGameState
    {
        [SerializeField] private float _bulletTimer, _timerCount;
      
        

        public GameBulletTime( GameSM stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            Debug.Log((Name));
            Time.timeScale = 1 / _timerCount;
            StartCoroutine(ReturnTime());
        }

        IEnumerator ReturnTime()
        {
            yield return new WaitForSeconds(_bulletTimer);
            Time.timeScale = 1;
            gameStateMachine.changeStateWithNaming.Invoke(TypeOfGameState.GameArena);
        }
       
    }
}
