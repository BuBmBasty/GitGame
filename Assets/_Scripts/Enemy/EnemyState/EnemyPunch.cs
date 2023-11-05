using _Scripts.StateMachine;
using UnityEngine;

namespace _Scripts.Enemy.EnemyState
{
    public class EnemyPunch : BaseState
    {
        private EnemySm _enemySm;
        private float _distance;
        private Vector3 _direction;
        public EnemyPunch(EnemySm stateMachine) : base("Punch", stateMachine)
        {
            _enemySm = stateMachine;
        }

        public override void Enter()
        {
            _enemySm.enemyAnimatorController.PunchAnimation(true);
            _enemySm.enemyAnimatorController.RunAnimation(0,0);
            _enemySm.character2DController.Move(0,0);
        }
    
        public override void UpdateLogic()
        {
            _distance = Vector3.Distance(_enemySm.target.position, _enemySm.thisTransform.position);
            if (_distance > _enemySm.punchDistance)
            {
                _enemySm.ChangeState(_enemySm.enemyRun);
            }
        }

        public override void UpdateMovement()
        {
            _direction = _enemySm.target.position - _enemySm.thisTransform.position;
            _enemySm.thisTransform.up = _direction.normalized;
        }
    }
}
