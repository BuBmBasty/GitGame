using UnityEngine;
using UnityEngine.Events;

public class GameSM : BaseGameStateMachine
{
    
    [HideInInspector] public  UnityEvent<string> ChangeStateWithNaming;

    [SerializeField] private BaseGameState _startState;
    [SerializeField] private BaseGameState[] _gameStates;

    #region SingleTone
    private static GameSM _instance;
    public static GameSM Instance => _instance;
    #endregion
    
    void Start()
    {
        ChangeStateWithNaming.AddListener(ChangeStateWithName);
        _gameStates = GetComponents<BaseGameState>();
        ChangeState(_startState);
        DontDestroyOnLoad(gameObject);
    }

    private void ChangeStateWithName(string nameState)
    {
        foreach (var state in _gameStates)
        {
            if (state.name == nameState)
                ChangeState(state);
        }
    }

    
}
