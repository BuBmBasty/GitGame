using _Scripts.Weapon;
using UnityEngine;

namespace _Scripts.SO
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapon Data", order = 51)]
    public class WeaponSO : ScriptableObject
    {
        public string name=>_name;
        public BaseGunController weapon=>_weapon;
        public Bullet bullet=>_bullet;
        public float damage=>_damage;
        public int blast=>_blast;
        public int spread=>_spread;
        public int magazine=>_magazine;
        public int startCostWeapon=>_startCostWeapon;
        public int startCostUpgrade=>_startCostUpgrade;
        public float upToUpdateCost=>_upToUpdateCost;
    
        [Header("Name of weapon")] 
        [SerializeField] private string _name;
        [Header("Prefabs")]
        [SerializeField] private BaseGunController _weapon;
        [SerializeField] private Bullet _bullet;

        [Header("Tactical and technical characteristics")] 
        [SerializeField] private float _damage;
        [SerializeField] private int _blast;
        [SerializeField] private int _spread;
        [SerializeField] private int _magazine;

        [Header("Monetary characteristics")] 
        [SerializeField] private int _startCostWeapon;
        [SerializeField] private int _startCostUpgrade;
        [SerializeField] private float _upToUpdateCost;
    }
}
