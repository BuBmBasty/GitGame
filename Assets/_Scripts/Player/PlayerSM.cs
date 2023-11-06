using _Scripts.Controllers;
using _Scripts.Player.PlayerState;
using _Scripts.SO;
using _Scripts.StateMachine;
using _Scripts.Weapon;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.Events;

namespace _Scripts.Player
{
    public class PlayerSm : BaseControllerSm
    {
        [HideInInspector] public  UnityEvent<Vector2, float> moveNoneGun;
        public Joystick MovementJoy => movementJoy;
        public Joystick FireJoystick => fireJoystick;
       
        [Header("Player controller")] 
        [SerializeField] private Joystick movementJoy;
        [SerializeField] public Joystick fireJoystick;

        [Header("Animation Rig Datas")] 
        [SerializeField] private ChainIKConstraint leftHandRig;
        [SerializeField] private ChainIKConstraint rightHandRig;

        public PlayerNonGun PlayerNonGun {get;private set; }

        public PlayerGunState PlayerGunState { get;private set; }

        public Transform ThisTransform{ get;private set; }

        public BaseGunController GunController{ get;private set; }

        [Header("Player start weapon")]
        [SerializeField] private WeaponSO startWeapon;

        private void Awake()
        {
            ThisTransform = GetComponent<Transform>();
        }


        private void Start()
        {
            GameController.instance.SetTarget(ThisTransform);
            
            PlayerNonGun = new PlayerNonGun(this);
            PlayerGunState = new PlayerGunState(this);
            
            CreateStartWeapon(startWeapon);
            ChangeState(PlayerNonGun);
        }
        protected override BaseState GetInitialState()
        {
            return PlayerNonGun;
        }
        private void CreateStartWeapon(WeaponSO weaponSo)
        {
            GunController = Instantiate(weaponSo.weapon, ThisTransform);
            leftHandRig.data.target = GunController.GetLeftHandTransform();
            rightHandRig.data.target = GunController.GetRightHandTransform();
            GunController.StartData(weaponSo.bullet,weaponSo.spread, weaponSo.magazine,weaponSo.blast,weaponSo.damage);
            GetComponent<AnimatorController>().RebindAnimator();
        }
    }
}
