using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace _Scripts.Player
{
    public class AnimatorController : MonoBehaviour
    {
        private Animator _animator;
        private RigBuilder _rigBuilder;
        private static readonly int InputY = Animator.StringToHash("InputY");
        private static readonly int InputX = Animator.StringToHash("InputX");
        private static readonly int Fire = Animator.StringToHash("Fire");

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _rigBuilder = GetComponentInChildren<RigBuilder>();
        }

        public void SetMovement(float input)
        {
            _animator.SetFloat(InputY, input);
        }
        public void SetMovement(float inputX, float inputY)
        {
            _animator.SetFloat(InputY, inputY);
            _animator.SetFloat(InputX, inputX);
        }

        public void SetFireState(bool isFire)
        {
            _animator.SetBool(Fire, isFire);
        }

        public void RebindAnimator()
        {
            _rigBuilder.Build();
            _animator.Rebind();
        }
    }
}
