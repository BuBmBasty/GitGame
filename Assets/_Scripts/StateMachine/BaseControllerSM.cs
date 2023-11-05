using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.StateMachine
{
    public class BaseControllerSm : BaseStateMachine
    {
        [HideInInspector] public  UnityEvent<float,float> Move;
        [HideInInspector] public  UnityEvent<bool> Fire;
        public float walkSpeed=>_walkSpeed;
        public float runSpeed=>_runSpeed;
        [Header("Player speed data")] 
        [SerializeField] public float _walkSpeed;
        [SerializeField] public float _runSpeed;
    }
}

