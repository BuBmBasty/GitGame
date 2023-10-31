using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.Controllers
{
    public class GameController : MonoBehaviour
    {
        public static GameController instance = null;
        public UnityEvent _enemyDead;
    
        [Header("Respawn data")]
        [SerializeField] private int _stageCount;
        [SerializeField] private int _maxEnemyOnMap;
        [SerializeField] private int _upCount;
        [SerializeField] private int _upEnemyOnMap;


        private Transform _target;
        private int _contEnemy, _deadEnemy, _startRes;
        private int _lvl;
        void Awake()
        {
            if (instance == null) 
            {
                instance = this; 
            } 
            else if(instance == this)
            { 
                Destroy(gameObject); 
            }
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            _enemyDead.AddListener(CheckEnemyCount);
            UIController.Instance.UpdateLevel(0);
            UIController.Instance.UpdateDeadEnemy(0);
            NewStageRespawn();
        }

        public Transform GetTarget()
        {
            return _target;
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }
    
        private void CheckEnemyCount()
        {
            _contEnemy--;
            _deadEnemy++;
            UIController.Instance.UpdateLiveEnemy(_contEnemy);
            UIController.Instance.UpdateDeadEnemy(_deadEnemy);
            if (_contEnemy + _deadEnemy < _stageCount-1)
            {
                for (int i = 0; i < _maxEnemyOnMap - _contEnemy;i++)
                {
                    if (_contEnemy+_deadEnemy >= _stageCount-1) break;
                    EnemyRespawn.Instance.CreateEnemyFromPool();
                }
            }
            else if (_contEnemy<=0)
            {
                StartCoroutine(StartNewStage());
            }
        }

        IEnumerator StartNewStage()
        {
            yield return new WaitForSeconds(5f);
            _deadEnemy=0;
            _stageCount += _upCount;
            _maxEnemyOnMap += _upEnemyOnMap;
            NewStageRespawn();
        }

        private void NewStageRespawn()
        {
            _lvl++;
            UIController.Instance.UpdateLevel(_lvl);
            UIController.Instance.UpdateDeadEnemy(0);
            UIController.Instance.UpdateLiveEnemy(0);
            UIController.Instance.NewStage(_lvl);
            if (_maxEnemyOnMap > _stageCount)
            {
                _startRes = _stageCount;
            }
            else
            {
                _startRes = _maxEnemyOnMap;
            }
            for (int i = 0; i < _startRes; i++)
            {
                EnemyRespawn.Instance.CreateEnemyFromPool();
            }
        }

        public void AddEnemy()
        {
            _contEnemy++;
            UIController.Instance.UpdateLiveEnemy(_contEnemy);
        }
    }
}
