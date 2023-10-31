using _Scripts.Controllers;
using _Scripts.Player.PlayerState;
using _Scripts.SO;
using _Scripts.StateMachine;
using _Scripts.Weapon;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace _Scripts.Player
{
    public class PlayerSM : BaseControllerSm
    {
        public AnimatorController animatorController => _animatorController;
        public Character2DController character2DController=>_character2DController;
        public Transform thisTransform=>_thisTransform;
        public float walkSpeed => _walkSpeed;
        public float runSpeed => _runSpeed;
        public Joystick movementJoy=>_movementJoy;
        public Joystick fireJoystick=>_fireJoystick;
        public PlayerNonGun playerNonGun=>_playerNonGun;
        public PlayerGunState playerGunState=>_playerGunState;
        public BaseGunController gunController=>_gunController;
    
        [Header("Player speed data")]
        [SerializeField] private float _walkSpeed;
        [SerializeField] private float _runSpeed;
    
        [Header("Player start weapon")]
        [SerializeField] private WeaponSO _startWeapon;
    
        [Header("Player controller")]
        [SerializeField] private Joystick _movementJoy;
        [SerializeField] private Joystick _fireJoystick;

        [Header("Animation Rig Datas")] 
        [SerializeField] private ChainIKConstraint _leftHandRig;
        [SerializeField] private ChainIKConstraint _rightHandRig;

        private PlayerNonGun _playerNonGun;
        private PlayerGunState _playerGunState;
        private AnimatorController _animatorController;
        private Character2DController _character2DController;
        private Transform _thisTransform;
        private BaseGunController _gunController;

        private void Awake()
        {
            _thisTransform = GetComponent<Transform>();
        }


        private void Start()
        {
            GameController.instance.SetTarget(_thisTransform);
            _animatorController = GetComponent<AnimatorController>();
            _character2DController = GetComponent<Character2DController>();
            _playerNonGun = new PlayerNonGun(this);
            _playerGunState = new PlayerGunState(this);
            CreateStartWeapon(_startWeapon);
            ChangeState(_playerNonGun);
        }
        protected override BaseState GetInitialState()
        {
            return _playerNonGun;
        }
        private void CreateStartWeapon(WeaponSO weaponSO)
        {
            _gunController = Instantiate(weaponSO.weapon, _thisTransform);
            _leftHandRig.data.target = _gunController.GetLeftHandTransform();
            _rightHandRig.data.target = _gunController.GetRightHandTransform();
            _gunController.StartData(weaponSO.bullet,weaponSO.spread, weaponSO.magazine,weaponSO.blast,weaponSO.damage);
            _animatorController.RebindAnimator();
        }
    }
}
