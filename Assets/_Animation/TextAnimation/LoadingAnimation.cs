using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class LoadingAnimation : MonoBehaviour
{
    [SerializeField] private string _loadingTextString = "Loading";
    [SerializeField] private float _timingAnimation;
    [SerializeField] private int _numberOfLettersInAnimations;
    private TMP_Text _loadingText;
    private float _currentTime;
    private int _currentIntString, _indexString;
    private string _currentString;

    private void Start()
    {
        _loadingText = GetComponent<TMP_Text>();
        _loadingText.text = _loadingTextString;
        _currentIntString = _numberOfLettersInAnimations;
        _indexString = _loadingTextString.Length;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _timingAnimation)
        {
            _currentTime = 0;
            if (_currentIntString >= _numberOfLettersInAnimations)
            {
                _currentIntString = 0;
                _currentString = _loadingTextString;
            }
            else
            {
                _currentIntString++;
                _currentString += ".";
            }

            _loadingText.text = _currentString;
        }
    }
}
