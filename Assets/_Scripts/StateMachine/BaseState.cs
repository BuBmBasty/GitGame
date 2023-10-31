
namespace _Scripts.StateMachine
{
    public class BaseState 
    {
        public string name;
        
        protected BaseStateMachine stateMachine;

        public BaseState(string name, BaseControllerSm stateMachine)
        {
            this.name = name;
            this.stateMachine = stateMachine;
        }

        public virtual void Enter() { }
        public virtual void UpdateLogic() { }
        public virtual void UpdatePhysics() { }
        public virtual void UpdateMovement() { }
        public virtual void Exit() {}
    }
}
