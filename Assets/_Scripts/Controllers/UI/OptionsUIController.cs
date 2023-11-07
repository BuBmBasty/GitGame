using _Scripts.Controllers;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUIController : MonoBehaviour
{
   [Header("Back buttons Options")]
   [SerializeField] private Button _backButton;
   [SerializeField] private GameObject _buttons;
   [Header("Sound Options")] 
   [SerializeField] private Button _soundButton;
   [SerializeField] private VolumeController _volumeController;
   [Header("Graphics Options")] 
   [SerializeField] private Button _graphicsButton;
   [SerializeField] private GraphicsUISetting _graphicsController;
   [Header("Game Options")] 
   [SerializeField] private Button _gameButton;
   [SerializeField] private VolumeController _gameController;

   private void Start()
   {
      _soundButton.onClick.AddListener(OnVolumeController);
      _graphicsButton.onClick.AddListener(OnGraphicsController);
      _gameButton.onClick.AddListener(OnGameController);
      _backButton.onClick.AddListener(BackInScreenLobby);
      _soundButton.onClick.Invoke();
   }

   private void BackInScreenLobby()
   {
      _buttons.SetActive(true);
      gameObject.SetActive(false);
   }

   private void OnGameController()
   {
      OnOffVolumeController(false);
      OnOffGraphicsController(false);
      OnOffGameController(true);
   }

   private void OnGraphicsController()
   {
      OnOffVolumeController(false);
      OnOffGraphicsController(true);
      OnOffGameController(false);
   }

   private void OnVolumeController()
   {
      OnOffVolumeController(true);
      OnOffGraphicsController(false);
      OnOffGameController(false);
   }

   private void OnOffVolumeController(bool isOn)
   {
      _volumeController.gameObject.SetActive(isOn);
   }
   private void OnOffGraphicsController(bool isOn)
   {
      _graphicsController.gameObject.SetActive(isOn);
   }
   private void OnOffGameController(bool isOn)
   {
      _gameController.gameObject.SetActive(isOn);
   }

   private void OnEnable()
   {
      _soundButton.onClick.Invoke();
   }
}
