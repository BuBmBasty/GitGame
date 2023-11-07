using TMPro;
using UnityEngine;

namespace _Scripts.Controllers
{
    public class UIController : MonoBehaviour
    {
        public static UIController Instance = null;
        
        [Header("Weapon data")]
        [SerializeField] private TMP_Text _ammo;
        [SerializeField] private TMP_Text _weaponName;
    
        [Header("Stage data")]
        [SerializeField] private TMP_Text _lvl;
        [SerializeField] private TMP_Text _liveZombies;
        [SerializeField] private TMP_Text _deadZombies;
        [SerializeField] private TMP_Text _newStage;

        private Animator _newStageAnimator;
        private static readonly int StageChange = Animator.StringToHash("StageChange");

        void Awake()
        {
            if (Instance == null) 
            {
                Instance = this; 
            } 
            else if(Instance == this)
            { 
                Destroy(gameObject); 
            }
            DontDestroyOnLoad(gameObject);
            _newStageAnimator = _newStage.gameObject.GetComponent<Animator>();
        }

        public void TextAmmoUpdate(int cont)
        {
            if (cont>0)
                _ammo.text = cont.ToString();
            else
            {
                _ammo.text = "Reloading";
            }
        }
        public void TextWeaponName(string name)
        {
            _weaponName.text = name;
        }

        public void UpdateLevel(int lvl)
        {
            _lvl.text = "Level: " + lvl;
        }
        public void UpdateLiveEnemy(int lEnemy)
        {
            _liveZombies.text = "Enemy Live: " + lEnemy;
        }
        public void UpdateDeadEnemy(int dEnemy)
        {
            _deadZombies.text = "Enemy Dead: " + dEnemy;
        }

        public void NewStage(int stage)
        {
            _newStage.text = "Stage: " + stage;
            _newStageAnimator.SetTrigger(StageChange);
        }
    }
}
