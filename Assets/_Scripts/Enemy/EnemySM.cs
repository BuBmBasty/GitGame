using _Scripts.Controllers;
using _Scripts.Enemy.EnemyState;
using _Scripts.Player;
using _Scripts.StateMachine;
using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.Enemy
{
    public class EnemySm : BaseControllerSm
    {
        public Transform target => _target;
        public Transform thisTransform => _thisTransform;
        public EnemyRun enemyRun => _enemyRun;
        public EnemyPunch enemyPunch => _enemyPunch;
        public EnemyAnimatorController enemyAnimatorController => _enemyAnimatorController;
        public Character2DController character2DController => _character2DController;
       
        public float punchDistance => _punchDistance;
    
        [SerializeField] private EnemyAnimatorController _enemyAnimatorController;
        [SerializeField] private float _punchDistance;

        [HideInInspector] public UnityEvent step;
        [HideInInspector] public UnityEvent wakeUp;
        [HideInInspector] public UnityEvent damage;
        [HideInInspector] public UnityEvent dead;

        private Transform _target, _thisTransform;
        private EnemyPunch _enemyPunch;
        private EnemyRun _enemyRun;
        private EnemyWakeUp _enemyWakeUp;
        private Character2DController _character2DController;

        private void Awake()
        {
            _enemyPunch = new EnemyPunch(this);
            _enemyRun = new EnemyRun(this);
            _enemyWakeUp = new EnemyWakeUp(this);
        }

        void Start()
        {
            _thisTransform = GetComponent<Transform>();
            _character2DController = GetComponent<Character2DController>();
            _target = GameController.instance.GetTarget();
            ChangeState(_enemyWakeUp);
        }

        private void OnEnable()
        {
            ChangeState(_enemyWakeUp);
        }
    }
}
