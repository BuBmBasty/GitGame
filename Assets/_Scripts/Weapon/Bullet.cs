using System.Collections;
using _Scripts.Abstract;
using UnityEngine;

namespace _Scripts.Weapon
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private LayerMask damageLayer;
        [SerializeField] private ParticleSystem misleParticle;
        [SerializeField] private Vector3 previousePosition;
        
        private Transform _thisTransform;
        private float _damage, _distance;
        private RaycastHit2D _hit;
    
    
        public void UpdateData(Vector3 startPoint, Vector3 direction, float damage)
        {
            _thisTransform = GetComponent<Transform>();
            _thisTransform.position = startPoint;
            previousePosition = startPoint;
            _thisTransform.up = new Vector3(direction.x,direction.y,0);
            _damage = damage;
        }

        private void OnEnable()
        {
            StartCoroutine(DestroyerBullet());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        // Update is called once per frame
        void Update()
        {
            _distance = Vector3.Distance(_thisTransform.position, previousePosition)*1.05f;
            _thisTransform.position += _thisTransform.up*speed * Time.deltaTime;
            _hit = Physics2D.Raycast(previousePosition, _thisTransform.up, _distance, damageLayer);
            if (_hit)
            {
                StopAllCoroutines();
                if (_hit.transform.TryGetComponent<Health>(out var healthController))
                {
                    healthController.Damage(_thisTransform.up,5);
                }
                else
                {
                    var particle = Instantiate(misleParticle);
                    var particleTransform = particle.transform;
                    particleTransform.position = _thisTransform.position;
                    particleTransform.forward = -1 * _thisTransform.up;
                }
                gameObject.SetActive(false);
            }
            previousePosition = _thisTransform.position;
        }

        IEnumerator DestroyerBullet()
        {
            yield return new WaitForSeconds(3f);
            gameObject.SetActive(false);
        }


    }
}
