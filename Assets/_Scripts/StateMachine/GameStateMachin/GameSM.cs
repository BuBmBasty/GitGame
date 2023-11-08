using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.StateMachine.GameStateMachin
{
    public class GameSm : BaseGameStateMachine
    {
    
        [HideInInspector] public  UnityEvent<TypeOfGameState> changeStateWithNaming;
        [HideInInspector] public UnityEvent<TypeOfGameState> findState;

        [SerializeField] private BaseGameState startState;
        [SerializeField] private BaseGameState[] gameStates;

        public TypeOfGameState previouseState => _previouseState;
        private TypeOfGameState _previouseState;
        
        #region SingleTone
        private static GameSm _instance;
        public static GameSm Instance => _instance;
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
        }

        #endregion
    
        void Start()
        {
            changeStateWithNaming.AddListener(ChangeStateWithName);
            gameStates = GetComponents<BaseGameState>();
            ChangeState(startState);
        }

       

        private void ChangeStateWithName(TypeOfGameState nameState)
        {
            foreach (var state in gameStates)
            {
                if (state.Name == nameState)
                {
                    _previouseState = currentState.Name;
                    ChangeState(state);
                }
            }
        }

        public BaseGameState FindState(TypeOfGameState needState)
        {
            Debug.Log("find");
            foreach (var state in gameStates)
            {
                if (state.Name == needState)
                {
                    return state;
                }
            }
            return null;
        }

    
    }
}
