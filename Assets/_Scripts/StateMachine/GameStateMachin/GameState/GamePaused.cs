using UnityEngine;

namespace _Scripts.StateMachine.GameStateMachin.GameState
{
    public class GamePaused : BaseGameState
    {
   
        public GamePaused(GameSM stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            Time.timeScale = 0;
        }
    }
}
