using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.StateMachine.GameStateMachin;
using _Scripts.StateMachine.GameStateMachin.GameState;
using UnityEngine;
using UnityEngine.UI;

public class GameUIControllers : MonoBehaviour
{
    [SerializeField] private GameBulletTime _gameBulletTime;
    [SerializeField] private Toggle _toogleBulletTimeOnOff;
    [SerializeField] private Slider _bulletTimer, _timeDilaed;

    private void Start()
    {
        _gameBulletTime = (GameBulletTime)GameSm.Instance.FindState(TypeOfGameState.GameBulletTime);
        _toogleBulletTimeOnOff.onValueChanged.AddListener(OnOffBulletTime);
        _bulletTimer.onValueChanged.AddListener(ChangeBulletTime);
        _timeDilaed.onValueChanged.AddListener(ChangeTimeScale);
    }

    private void OnEnable()
    {
        if (_gameBulletTime == null)
            _gameBulletTime = (GameBulletTime)GameSm.Instance.FindState(TypeOfGameState.GameBulletTime);
        _bulletTimer.value = _gameBulletTime.bulletTimer/5;
        _timeDilaed.value =  _gameBulletTime.timerCount/4;
    }

    private void ChangeTimeScale(float pos)
    {
        pos = Mathf.Lerp(1, 4, pos);
        _gameBulletTime.timerCount = pos;
    }

    private void ChangeBulletTime(float pos)
    {
        pos = Mathf.Lerp(1, 5, pos);
        _gameBulletTime.bulletTimer = pos;
    }

    private void OnOffBulletTime(bool isOn)
    {
        _gameBulletTime.isOn = isOn;
    }
}
