using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.StateMachine.GameStateMachin
{
    public class GameSM : BaseGameStateMachine
    {
    
        [HideInInspector] public  UnityEvent<string> changeStateWithNaming;

        [SerializeField] private BaseGameState startState;
        [SerializeField] private BaseGameState[] gameStates;

        #region SingleTone
        private static GameSM _instance;
        public static GameSM Instance => _instance;

        private void Awake()
        {
            if (Instance == null) 
            {
                _instance = this; 
            } 
            else if(Instance == this)
            { 
                Destroy(gameObject); 
            }
            DontDestroyOnLoad(gameObject);
#if  UNITY_EDITOR
            Application.targetFrameRate = 120;
#else  
            Application.targetFrameRate = 60;
#endif
        }

        #endregion
    
        void Start()
        {
            changeStateWithNaming.AddListener(ChangeStateWithName);
            gameStates = GetComponents<BaseGameState>();
            ChangeState(startState);
        }

        private void ChangeStateWithName(string nameState)
        {
            foreach (var state in gameStates)
            {
                if (state.name == nameState)
                {
                    ChangeState(state);
                }
            }
        }

    
    }
}
