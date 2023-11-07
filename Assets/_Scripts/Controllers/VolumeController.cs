using UnityEngine;
using UnityEngine.Audio;
using Unity.UI;
using UnityEngine.UI;

namespace _Scripts.Controllers
{
    public class VolumeController : MonoBehaviour
    {
        [SerializeField] private AudioMixer _mixer;
        [SerializeField] private Toggle _toogleSoundOnOff;
        void Start()
        {
            _toogleSoundOnOff.onValueChanged.AddListener(SoundOnOff);
        }

        private void SoundOnOff(bool isOn)
        {
            if (isOn)
                _mixer.SetFloat("MasterVolume", 0);
            else
            {
                _mixer.SetFloat("MasterVolume", -80);
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
