using System.Collections;
using _Scripts.StateMachine.GameStateMachin;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUIController : MonoBehaviour
{
    [SerializeField] private GameObject _buttonPanel;
    [Header("Play Button Setting")]
    [SerializeField] private Button _playButton;
    [SerializeField] private TypeOfGameState _startGameState;
    [Header("Options Button Setting")]
    [SerializeField] private Button _optionsButton;
    [SerializeField] private GameObject _optionsWindow;
    [Header("Exit Button Setting")]
    [SerializeField] private Button _exitButton;
    [Header("Loading panel Setting")]
    [SerializeField] private GameObject _loadingPanel;
    void Start()
    {
        _playButton.onClick.AddListener(Play);
        _optionsButton.onClick.AddListener(OpenOptionsWindow);
        _loadingPanel.SetActive(false);
        _optionsWindow.SetActive(false);
        _buttonPanel.SetActive(true);
    }

    private void OpenOptionsWindow()
    {
        _optionsWindow.SetActive(true);
        _buttonPanel.SetActive(false);
    }

    private void Play()
    {
        _playButton.gameObject.SetActive(false);
        _optionsButton.gameObject.SetActive(false);
        _exitButton.gameObject.SetActive(false);
        _loadingPanel.SetActive(true);
        var timer = Random.Range(1, 5);
        StartCoroutine(StartGameCoroutine(timer));
    }

    IEnumerator StartGameCoroutine(float timer)
    {
        yield return new WaitForSeconds(timer);
        GameSm.Instance.changeStateWithNaming.Invoke(_startGameState);
    }
}
