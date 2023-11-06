using UnityEngine;

public class BaseGameState : MonoBehaviour
{
   
        
    protected BaseGameStateMachine stateMachine;

    public BaseGameState(string name, BaseGameStateMachine stateMachine)
    {
        this.name = name;
        this.stateMachine = stateMachine;
    }
    public virtual void Enter() {}
    public virtual void UpdateLogic() {}
    public virtual void Exit() {}
}
