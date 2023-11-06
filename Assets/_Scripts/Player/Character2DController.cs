using _Scripts.StateMachine;
using UnityEngine;

namespace _Scripts.Player
{
    public class Character2DController : MonoBehaviour
    {
        private CircleCollider2D _collider;
        private Rigidbody2D _rb2D;
        void Start()
        {
            _collider = GetComponent<CircleCollider2D>();
            _rb2D = GetComponent<Rigidbody2D>();
            GetComponent<BaseControllerSm>().Move.AddListener(Move);
            if (TryGetComponent<PlayerSm>(out var playerSM))
                playerSM.moveNoneGun.AddListener(Move);
        }

        public void Move(float inputX, float inputY)
        {
            _rb2D.velocity = new Vector2(inputX,inputY);
        }
        public void Move(Vector2 move, float inputY)
        {
            _rb2D.velocity = move;
        }
    }
}
