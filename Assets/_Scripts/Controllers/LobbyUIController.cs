using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUIController : MonoBehaviour
{
    [Header("Play Button Setting")]
    [SerializeField] private Button _playButton;
    [SerializeField] private string _nameGameState;
    [Header("Options Button Setting")]
    [SerializeField] private Button _optionsButton;
    [Header("Exit Button Setting")]
    [SerializeField] private Button _exitButton;
    [Header("Loading panel Setting")]
    [SerializeField] private GameObject _loadingPanel;
    void Start()
    {
        _playButton.onClick.AddListener(Play);
        _loadingPanel.SetActive(false);
    }

    private void Play()
    {
        _playButton.gameObject.SetActive(false);
        _optionsButton.gameObject.SetActive(false);
        _exitButton.gameObject.SetActive(false);
        _loadingPanel.SetActive(true);
        StartCoroutine(StartGameCoroutine());
    }

    IEnumerator StartGameCoroutine()
    {
        yield return new WaitForSeconds(Random.Range(10, 20));
        GameSM.Instance.ChangeStateWithNaming.Invoke(_nameGameState);
    }
}
