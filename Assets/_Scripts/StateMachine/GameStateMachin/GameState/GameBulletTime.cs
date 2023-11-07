using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.StateMachine.GameStateMachin.GameState
{
    public class GameBulletTime : BaseGameState
    {
        public bool isOn=true;
        public float bulletTimer=5;
        public float timerCount=4;


        public GameBulletTime( GameSM stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            if (timerCount <= 0) timerCount = 1;
            Debug.Log((Name + " Timer: " + bulletTimer + ". Count: " + timerCount));
            if (isOn)
                Time.timeScale = 1 / timerCount;
            StartCoroutine(ReturnTime());
        }

        IEnumerator ReturnTime()
        {
            yield return new WaitForSeconds(bulletTimer);
            Time.timeScale = 1;
            gameStateMachine.changeStateWithNaming.Invoke(TypeOfGameState.GameArena);
        }
       
    }
}
