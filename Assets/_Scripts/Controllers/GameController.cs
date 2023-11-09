using System;
using System.Collections;
using _Scripts.Player;
using _Scripts.StateMachine.GameStateMachin;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace _Scripts.Controllers
{
    public class GameController : MonoBehaviour
    {
        public static GameController instance = null;
        public Transform target => _target;
        public PlayerHealthController playerHealthController => _playerHealthController;
        
        [HideInInspector]public UnityEvent enemyDead;
        [HideInInspector]public UnityEvent <PlayerHealthController> playerAdd;
        [Header("Data from bullettime visual")]
        [SerializeField] private CinematicCameraTransform _cinemaCamera;     
        [Header("Respawn data")]
        [SerializeField] private int _stageCount;
        [SerializeField] private int _maxEnemyOnMap;
        [SerializeField] private int _upCount;
        [SerializeField] private int _upEnemyOnMap;


        private Transform _target;
        private PlayerHealthController _playerHealthController;
        private int _contEnemy, _deadEnemy, _startRes;
        private int _lvl;

        #region Singletone
        private void Awake()
        {
            _cinemaCamera.gameObject.SetActive(false);
            if (instance == null) 
            {
                instance = this; 
            } 
            else if(instance == this)
            { 
                Destroy(gameObject); 
            }
            DontDestroyOnLoad(gameObject);
            playerAdd.AddListener(SetTarget);
            enemyDead.AddListener(CheckEnemyCount);
        }
        #endregion

        
        private void Start()
        {
            UIController.Instance.UpdateLevel(0);
            UIController.Instance.UpdateDeadEnemy(0);
            NewStageRespawn();
        }

        public void SetTarget(PlayerHealthController targetIn)
        {
            _target = targetIn.transform;
            _playerHealthController = targetIn;
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
                    StartCoroutine(RandomiserTimeToRespawn());
                }
            }
            else if (_contEnemy<=0)
            {
                _cinemaCamera.gameObject.SetActive(true);
                _cinemaCamera.target = EnemyRespawn.Instance.FinalEnemyTransform();
                GameSm.Instance.changeStateWithNaming.Invoke(TypeOfGameState.GameBulletTime);
                StartCoroutine(StartNewStage());
            }
        }

        IEnumerator StartNewStage()
        {
            yield return new WaitForSeconds(5f);
            _cinemaCamera.gameObject.SetActive(false);
            _deadEnemy=0;
            _stageCount += _upCount;
            _maxEnemyOnMap += _upEnemyOnMap;
            NewStageRespawn();
        }

        private async void NewStageRespawn()
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
                StartCoroutine(RandomiserTimeToRespawn());
            }
        }

        IEnumerator RandomiserTimeToRespawn()
        {
            yield return new WaitForSeconds(Random.Range(0, 3));
            EnemyRespawn.Instance.RespawnEnemy.Invoke();
        }

        public void AddEnemy()
        {
            _contEnemy++;
            UIController.Instance.UpdateLiveEnemy(_contEnemy);
        }
    }
}
