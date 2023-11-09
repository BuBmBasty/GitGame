using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GraphicsUISetting : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _qualitySetting;

    void Start()
    {
        _qualitySetting.onValueChanged.AddListener(Quality);
    }

    private void OnEnable()
    {
      _qualitySetting.SetValueWithoutNotify(QualitySettings.GetQualityLevel());
    }

    private void Quality(int set)
    {
        QualitySettings.SetQualityLevel(set, false);
    }

  

}
