using _Scripts.StateMachine;

namespace _Scripts.Enemy.EnemyState
{
    public class EnemyWakeUp : BaseState
    {
        private EnemySm _enemySm;

        public EnemyWakeUp(EnemySm stateMachine) : base("WakeUp", stateMachine)
        {
            _enemySm = stateMachine;
        }

        public override void Enter()
        {
            _enemySm.enemyAnimatorController.RunAnimation(0);
        }


        public override void UpdateLogic()
        {
            if (_enemySm.enemyAnimatorController.isWakeUp)
            {
                _enemySm.ChangeState(_enemySm.enemyRun);
            }
        }
    }
}
