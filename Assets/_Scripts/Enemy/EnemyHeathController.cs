using _Scripts.Abstract;
using _Scripts.Controllers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace _Scripts.Enemy
{
    public class EnemyHeathController : Health
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _punchForse;
        [SerializeField] private ParticleSystem _blood;
        [SerializeField] private Transform _punchTransform;
        [SerializeField] private Rig _rigController;
        [SerializeField] private Animator _animator;
    
        private CircleCollider2D _collider2D;
        private Rigidbody2D _rigidbody2D;
        private Transform _thisTransform;
        private float _rigControllerZ, _currentHealth;
        private RagdollController _ragdollController;
        private bool _isDead;
        private EnemySm _enemySM;
        private static readonly int Reset = Animator.StringToHash("Reset");

        private void Awake()
        {
            _enemySM = GetComponent<EnemySm>();
            _thisTransform = GetComponent<Transform>();
            _collider2D = GetComponent<CircleCollider2D>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigControllerZ = _punchTransform.position.z;
            _currentHealth = _maxHealth;
            _ragdollController = GetComponent<RagdollController>();
            DOTween.Init();
        }

        private void OnEnable()
        {
            _enemySM.enabled = true;
            _isDead = false;
            _animator.enabled = true;
            _currentHealth = _maxHealth;
            _rigidbody2D.isKinematic =false;
            _animator.SetTrigger(Reset);
        }

        public override void Damage(Vector3 direction, float damage)
        {
            DOTween.KillAll();
            _rigController.weight = 0;
            _blood.transform.forward = direction;
            _blood.Play();
            _currentHealth -= damage;
            if (_currentHealth <= 0 && !_isDead)
            {
                Dead(damage,direction);
            }
            else if (!_isDead)
            {
                DOTween.To(() => _rigController.weight, x => _rigController.weight = x, 1, 0.5f)
                    .OnComplete(() => DOTween.To(() => _rigController.weight, x => _rigController.weight = x, 0, 0.5f));
                _punchTransform.position =
                    new Vector3(_thisTransform.position.x, _thisTransform.position.y, _rigControllerZ) +
                    direction * _punchForse;
            }
        }

        private void Dead(float damage, Vector3 direction)
        {
            _enemySM.enabled = false;
            _isDead = true;
            _collider2D.enabled = false;
            _rigidbody2D.isKinematic =true;
            _rigidbody2D.velocity = Vector2.zero;
            _animator.enabled = false;
            _ragdollController.AddRagDoll();
            _ragdollController.AddForce(direction*damage*10);
        }
    }
}
