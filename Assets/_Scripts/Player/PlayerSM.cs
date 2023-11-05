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
        [HideInInspector] public  UnityEvent<Vector2, float> MoveNoneGun;
        public Joystick movementJoy => _movementJoy;
        public Joystick fireJoystick => _fireJoystick;
        [Header("Player controller")] 
        [SerializeField] private Joystick _movementJoy;
        [SerializeField] public Joystick _fireJoystick;

        [Header("Animation Rig Datas")] 
        [SerializeField] private ChainIKConstraint _leftHandRig;

        [SerializeField] private ChainIKConstraint _rightHandRig;

        public PlayerNonGun playerNonGun {get;private set; }

        public PlayerGunState playerGunState { get;private set; }

        public Transform thisTransform{ get;private set; }

        public BaseGunController gunController{ get;private set; }

        [Header("Player start weapon")]
        [SerializeField] private WeaponSO _startWeapon;

        private void Awake()
        {
            thisTransform = GetComponent<Transform>();
        }


        private void Start()
        {
            GameController.instance.SetTarget(thisTransform);
            
            playerNonGun = new PlayerNonGun(this);
            playerGunState = new PlayerGunState(this);
            
            CreateStartWeapon(_startWeapon);
            ChangeState(playerNonGun);
        }
        protected override BaseState GetInitialState()
        {
            return playerNonGun;
        }
        private void CreateStartWeapon(WeaponSO weaponSO)
        {
            gunController = Instantiate(weaponSO.weapon, thisTransform);
            _leftHandRig.data.target = gunController.GetLeftHandTransform();
            _rightHandRig.data.target = gunController.GetRightHandTransform();
            gunController.StartData(weaponSO.bullet,weaponSO.spread, weaponSO.magazine,weaponSO.blast,weaponSO.damage);
            GetComponent<AnimatorController>().RebindAnimator();
        }
    }
}
