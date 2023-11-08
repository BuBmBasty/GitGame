using System;
using UnityEngine;

namespace _Scripts.Enemy
{
    public class EnemyAnimatorController : MonoBehaviour
    {
        public bool isWakeUp => _isWakeUp;
    
        [SerializeField] private ParticleSystem _particleWakeUp;
        [SerializeField] private CircleCollider2D _circleCollider;
        [SerializeField] private Animator _animator;
        private bool _isWakeUp;
        private EnemySm _enemySm;
        private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");
        private static readonly int Punch = Animator.StringToHash("Punch");

        private void Start()
        {
            _enemySm = GetComponentInParent<EnemySm>();
            _enemySm.Move.AddListener(RunAnimation);
        }

        public void StartWakeUp()
        {
            _isWakeUp = false;
            _particleWakeUp.Play();
        }
        public void EndWakeUp()
        {
            _particleWakeUp.Stop();
            _circleCollider.enabled = true;
            _isWakeUp = true;
        }

        public void RunAnimation(float speedX, float speedY)
        {
            if (speedY !=0)
                _animator.SetFloat(MoveSpeed,1);
            else
                _animator.SetFloat(MoveSpeed,0);
        }
        public void PunchAnimation(bool isPunch)
        {
            _animator.SetBool(Punch,isPunch);
        }

        public void StepSound()
        {
            _enemySm.step.Invoke();
        }
    }
}
