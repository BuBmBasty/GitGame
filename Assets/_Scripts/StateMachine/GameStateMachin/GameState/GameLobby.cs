using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.StateMachine.GameStateMachin.GameState
{
    public class GameLobby : BaseGameState
    {
        [Header("OSTMusic")] 
        [SerializeField] private AudioClip _start;
        [SerializeField] private AudioClip _loop;
        public GameLobby(GameSm stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            Debug.Log(Name);
            if (SceneManager.GetActiveScene().name != "Lobby")
            {
                OSTController.Instance.newOstMusic.Invoke(_start,_loop);
                SceneManager.LoadScene("Lobby");
            }
        }
    }
}
