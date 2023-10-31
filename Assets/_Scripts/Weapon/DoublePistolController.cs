using _Scripts.Controllers;
using UnityEngine;

namespace _Scripts.Weapon
{
    public class DoublePistolController : BaseGunController
    {
        private static readonly int Fire1 = Animator.StringToHash("Fire");
        private static readonly int Reload1 = Animator.StringToHash("Reload");

        private void Start()
        {
            UIController.Instance.TextWeaponName(_weaponName);
        }

        public override void Fire(bool isFire)
        {
            _animator.SetBool(Fire1, isFire);
        }

        public void GunFire(int i)
        {
            if (_currentBullet <= 0)
            {
                Reload();
                return;
            }
            _currentBullet--;
            UIController.Instance.TextAmmoUpdate(_currentBullet);
            missles[i].Play();
            gilzes[i].Play();
            foreach (var bullet in BulletList)
            {
                if (!bullet.gameObject.activeSelf)
                {
                    bullet.UpdateData(firePoint[i].position, firePoint[i].up, _damage);
                    bullet.gameObject.SetActive(true);
                    return;
                }
            }
            CreatePool();
            BulletList[^1].UpdateData(firePoint[i].position, firePoint[i].up, _damage);
            BulletList[^1].gameObject.SetActive(true);
        }
    
        public override void Reload()
        {
            _animator.SetTrigger(Reload1);
        }

        public void EndReload()
        {
            _currentBullet = _magazine;
            UIController.Instance.TextAmmoUpdate(_currentBullet);
        }
    }
}
