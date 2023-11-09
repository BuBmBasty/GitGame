using _Scripts.Abstract;
using _Scripts.Controllers;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerHealthController : Health
    {
        [SerializeField] private float _startHealth;

        private float _currentHealth;
        private void Start()
        {
            GameController.instance.playerAdd.Invoke(this);
            _currentHealth = _startHealth;
        }

        public override void Damage(Vector3 direction, float damage)
        {
            _currentHealth -= damage;
        }
    }
}
