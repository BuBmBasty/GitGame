using UnityEngine;

namespace _Scripts.StateMachine.GameStateMachin
{
    public class BaseGameState : MonoBehaviour
    {
        public string name;
        
        protected BaseGameStateMachine StateMachine;

        public BaseGameState(string name, BaseGameStateMachine stateMachine)
        {
            this.name = name;
            StateMachine = stateMachine;
        }
        public virtual void Enter() {}
        public virtual void UpdateLogic() {}
        public virtual void Exit() {}
    }
}
