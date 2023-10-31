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
        }

        public void Move(Vector2 direction)
        {
            _rb2D.velocity = direction;
        }
    }
}
