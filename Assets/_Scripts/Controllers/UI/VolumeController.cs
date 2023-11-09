using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace _Scripts.Controllers
{
    public class VolumeController : MonoBehaviour
    {
        [SerializeField] private AudioMixer _mixer;
        [SerializeField] private Toggle _toogleSoundOnOff;
        [SerializeField] private Slider _masterSlider, _musicSlider, _effectSlider, _dictorSlider;

        private float _settingMasterVolume;
        private void Start()
        {
            _toogleSoundOnOff.onValueChanged.AddListener(SoundOnOff);
            _masterSlider.onValueChanged.AddListener(MasterVolume);
            _musicSlider.onValueChanged.AddListener(MusicVolume);
            _effectSlider.onValueChanged.AddListener(EffectsVolume);
            _dictorSlider.onValueChanged.AddListener(DictorVolume);
        }

        private void OnEnable()
        {
            _mixer.GetFloat("MasterVolume", out var change);
            _masterSlider.value =(80+ change) / 80;
            _settingMasterVolume = change;
            _mixer.GetFloat("MusicVolume", out  change);
            _musicSlider.value = (80+ change) / 80;
            _mixer.GetFloat("EffectsVolume", out  change);
            _effectSlider.value =(80+ change) / 80;
            _mixer.GetFloat("DictorVolume", out  change);
            _dictorSlider.value =(80+ change) / 80;
        }

        private void MasterVolume(float volume)
        {
            _settingMasterVolume = volume;
            volume = Mathf.Lerp(-80, 0, volume);
            _mixer.SetFloat("MasterVolume", volume);
        }
        private void MusicVolume(float volume)
        {
            volume = Mathf.Lerp(-80, 0, volume);
            _mixer.SetFloat("MusicVolume", volume);
        }
        private void EffectsVolume(float volume)
        {
            volume = Mathf.Lerp(-80, 0, volume);
            _mixer.SetFloat("EffectsVolume", volume);
        }
        private void DictorVolume(float volume)
        {
            volume = Mathf.Lerp(-80, 0, volume);
            _mixer.SetFloat("DictorVolume", volume);
        }

        private void SoundOnOff(bool isOn)
        {
            if (isOn)
                _mixer.SetFloat("MasterVolume", _settingMasterVolume);
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
