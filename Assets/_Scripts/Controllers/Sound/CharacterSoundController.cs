using UnityEngine;

namespace _Scripts.Controllers.Sound
{
    public class CharacterSoundController : MonoBehaviour
    {
        public AudioClip[] stepSound => _stepSound;
        public AudioSource voiceAudioSource => _audioSource;
        public AudioClip[] damageSound => _damageSound;
        [SerializeField] private AudioClip[] _stepSound, _wakeUpSound, _damageSound, _deadSound;
        private AudioSource _audioSource;
        private float _randomisePitch;
        public virtual void Start()
        {
            _audioSource = GetComponent<AudioSource>();
           
        }

        public virtual  void StepSound()
        {
            _randomisePitch = Random.Range(0.8f, 1f);
            _audioSource.pitch = _randomisePitch;
            _audioSource.Play();
        }
        public virtual void WakeUpSound()
        {
            _audioSource.clip = _wakeUpSound[Random.Range(0, _wakeUpSound.Length)];
            _randomisePitch = Random.Range(0.95f, 1.05f);
            _audioSource.Play();
            _audioSource.pitch = _randomisePitch;
        }
        public virtual void DamageSound()
        {
            _randomisePitch = Random.Range(0.95f, 1.05f);
            _audioSource.pitch = _randomisePitch;
            _audioSource.Play();
        }
        public virtual void DeadSound()
        {
            _audioSource.clip = _wakeUpSound[Random.Range(0, _deadSound.Length)];
            _randomisePitch = Random.Range(0.8f, 1.1f);
            _audioSource.pitch = _randomisePitch;
            _audioSource.Play();
        }
    }
}
