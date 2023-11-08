using _Scripts.Controllers.Sound;
using UnityEngine;

namespace _Scripts.Enemy
{
    public class EnemySoundController : CharacterSoundController
    {
        [Header("Voise Data")] 
        [Range(0, 1)] [SerializeField] private float _voiceVolume;
        [Header("StepSound Data")] 
        [SerializeField] private AudioSource _stepAudioSource;
        [Range(0, 1)][SerializeField] private float _stepVolume;
        [Header("BodySound Data")] 
        [SerializeField] private AudioSource _damageAudioSource;
        [Range(0, 1.1f)][SerializeField] private float _bodyVolume;
        private EnemySm _enemySm;
        private float _randomisePitchThis;
        public void OnEnable()
        {
            _enemySm = GetComponent<EnemySm>();
            _enemySm.damage.AddListener(DamageSound);
            _enemySm.step.AddListener(StepSound);
            _enemySm.wakeUp.AddListener(WakeUpSound);
            _enemySm.dead.AddListener(DeadSound);
            base.Start();
            _damageAudioSource.clip = damageSound[Random.Range(0, damageSound.Length)];
            _stepAudioSource.clip = stepSound[Random.Range(0, stepSound.Length)];
            _damageAudioSource.volume = _bodyVolume;
            _stepAudioSource.volume = _stepVolume;
            voiceAudioSource.volume = _voiceVolume;
        }

        public override void DamageSound()
        {
            _randomisePitchThis = Random.Range(0.8f, 1f);
            _damageAudioSource.pitch = _randomisePitchThis;
            _damageAudioSource.Play();
        }

        public override void StepSound()
        {
            _randomisePitchThis = Random.Range(0.85f, 1.0f);
            _stepAudioSource.pitch = _randomisePitchThis;
            _stepAudioSource.Play();
        }
    }
}
