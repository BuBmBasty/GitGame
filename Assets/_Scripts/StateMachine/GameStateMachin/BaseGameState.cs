using System;
using UnityEngine;

namespace _Scripts.StateMachine.GameStateMachin
{
    public class BaseGameState : MonoBehaviour
    {
        public TypeOfGameState Name=>_name;
        public GameSM gameStateMachine => _gameStateMachine;
        private GameSM _gameStateMachine;
        protected BaseGameStateMachine StateMachine;
        [SerializeField] private TypeOfGameState _name;

        private void Start()
        {
            _gameStateMachine = GetComponent<GameSM>();
        }

        public BaseGameState(BaseGameStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }
        public virtual void Enter() {}
        public virtual void UpdateLogic() {}
        public virtual void Exit() {}
    }

    public enum TypeOfGameState
    {
        GameArena,
        GameBulletTime,
        GameLobby,
        GamePause,
        GameShop
    }
}
