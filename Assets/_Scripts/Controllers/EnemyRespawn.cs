using System.Collections;
using System.Collections.Generic;
using _Scripts.Enemy;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Controllers
{
    public class EnemyRespawn : MonoBehaviour
    {
        public static EnemyRespawn Instance;
    
        [SerializeField] private EnemySm _zombie;
        [SerializeField] private float _radiusRespawn;
        [SerializeField] private int _poolCount;

        private List<EnemySm> _enemySms = new();
        private float _randX, _randY, _randAngle;


        private void Awake() 
        {
            if (Instance == null) 
            {
                Instance = this; 
            } 
            else if(Instance == this)
            { 
                Destroy(gameObject); 
            }
            DontDestroyOnLoad(gameObject);
        }
        private void Start()
        {
            for (int i = 0; i < _poolCount; i++)
            {
                PoolEnemyCreate();
            }
        }

        public void CreateEnemyFromPool()
        {
            foreach (var enemy in _enemySms)
            {
                if (!enemy.isActive)
                {
                    enemy.isActive = true;
                    StartCoroutine(ActivateEnemy(enemy));
                    return;
                }
            }
            PoolEnemyCreate();
            ActivateEnemy(_enemySms[^1]);
        }

        private IEnumerator ActivateEnemy(EnemySm enemySm)
        {
            yield return new WaitForSeconds(Random.Range(0,3));
            enemySm.gameObject.SetActive(true);
            _randX = Random.Range(-1*_radiusRespawn, _radiusRespawn);
            _randY = Random.Range(-1*_radiusRespawn, _radiusRespawn);
            _randAngle = Random.Range(0, 360);
            enemySm.transform.position = new Vector3(_randX, _randY, 0);
            enemySm.transform.rotation = quaternion.Euler(0, 0, _randAngle);
            GameController.instance.AddEnemy();
        }

        private void PoolEnemyCreate()
        {
            var enemy = Instantiate(_zombie,transform);
            _enemySms.Add(enemy);
            enemy.gameObject.SetActive(false);
        }

    }
}
