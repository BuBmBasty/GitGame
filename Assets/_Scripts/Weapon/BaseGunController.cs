using System.Collections.Generic;
using _Scripts.Controllers;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Weapon
{
    public class BaseGunController : MonoBehaviour
    {
        [SerializeField] protected string _weaponName = "Double Pistols";
       
        [Header("Visuals ParticleSystem")]
        [SerializeField] protected ParticleSystem[] missles;
        [SerializeField] protected ParticleSystem[] gilzes;
    
        [Header("Transforms datas")]
        [SerializeField] protected Transform[] firePoint;
        [SerializeField] private Transform leftHandTransform;
        [SerializeField] private Transform rightHandTransform;

        protected Bullet _bullet;
        protected Animator _animator;
        protected List<Bullet> BulletList = new();
        
        protected int _magazine, _currentBullet;
        protected float _damage;

        private int _pellets;
        private float _splash;


        public Transform GetLeftHandTransform()
        {
            return leftHandTransform;
        }
        public Transform GetRightHandTransform()
        {
            return rightHandTransform;
        }

        public void StartData(Bullet bullet, int pellets, int magazine, float blaze, float damage)
        {
            _bullet = bullet;
            _pellets = pellets;
            _magazine = magazine;
            _splash = blaze;
            _damage = damage;
        
            _animator = GetComponent<Animator>();
            _currentBullet = _magazine;
            
            for (int i = 0; i < _magazine/2; i++)
            {
                CreatePool();
            }
        }

        private void Start()
        {
            UIController.Instance.TextAmmoUpdate(_currentBullet);
        }

        protected void CreatePool()
        {
            var bullet = Instantiate(this._bullet);
            BulletList.Add(bullet);
            bullet.gameObject.SetActive(false);
        }

        public virtual void Fire(bool isFire)
        {
        
        }
        public virtual void Reload()
        {
        
        }
    }
}
