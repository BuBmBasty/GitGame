using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsUISetting : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _resolutionSetting, _shadowSetting;

    private int _screenHeight, _screenWidht; 
    void Start()
    {
        _screenHeight = Screen.height;
        _screenWidht = Screen.width;
        Debug.Log(_screenHeight + " / " + _screenWidht);
        _resolutionSetting.onValueChanged.AddListener(ChangeResolution);
        _shadowSetting.onValueChanged.AddListener(ChangeShadow);
    }

    private void ChangeShadow(int set)
    {
        
            QualitySettings.SetQualityLevel(set, false);
        
    }

    private void ChangeResolution(int set)
    {
        Debug.Log(_screenHeight + " / " + _screenWidht + " // " +set);
        Screen.SetResolution(_screenWidht/(1+set),_screenHeight/(1+set),FullScreenMode.FullScreenWindow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
