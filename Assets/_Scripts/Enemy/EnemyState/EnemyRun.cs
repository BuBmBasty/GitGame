using _Scripts.StateMachine;
using UnityEngine;

namespace _Scripts.Enemy.EnemyState
{
    public class EnemyRun : BaseState
    {
        private EnemySm _enemySm;
        private Vector3 _direction;
        private float _distance;

        public EnemyRun(EnemySm stateMachine) : base("Run", stateMachine)
        {
            _enemySm = stateMachine;
        }

        public override void Enter()
        {
            _enemySm.Move.Invoke(0,1);
            _enemySm.enemyAnimatorController.PunchAnimation(false);
        }

        public override void UpdateLogic()
        {
            _distance = Vector3.Distance(_enemySm.target.position, _enemySm.thisTransform.position);
            if (_distance <= _enemySm.punchDistance)
            {
                _enemySm.ChangeState(_enemySm.enemyPunch);
            }
        }

        public override void UpdateMovement()
        {
            _direction = _enemySm.target.position - _enemySm.thisTransform.position;
            _enemySm.thisTransform.up = _direction.normalized;
            _enemySm.Move.Invoke(_direction.normalized.x*_enemySm.runSpeed,_direction.normalized.y*_enemySm.runSpeed);
        }
    }
}
