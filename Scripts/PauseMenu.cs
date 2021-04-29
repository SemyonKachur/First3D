using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] private GameObject _pausePanel = null;
    [SerializeField] private Button _resumeGame = null;
    [SerializeField] private Button _options = null;
    [SerializeField] private Button _quit = null;
    [Header("Options")]
    [SerializeField] private GameObject _optionsPanel = null;
    [SerializeField] private Button _back = null;
    [SerializeField] private Toggle _soundOn = null;
    [SerializeField] private Slider _soundSlider = null;
    [SerializeField] private AudioSource _mainMusic = null;
    [Header("Win")]
    [SerializeField] public GameObject _winPanel = null;
    [SerializeField] private Button _restartButton = null;
    [SerializeField] private Button _winQuit = null;
    [Header("Loose")]
    [SerializeField] public GameObject _loosePanel = null;
    [SerializeField] private Button _looseRestartButton = null;
    [SerializeField] private Button _looseQuit = null;

    private void Awake()
    {
        _mainMusic = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioSource>();
        _resumeGame.onClick.AddListener(ResumeGame);
        _restartButton.onClick.AddListener(RestartGame);
        _looseRestartButton.onClick.AddListener(RestartGame);

        _quit.onClick.AddListener(QuitGame);
        _winQuit.onClick.AddListener(QuitGame);
        _looseQuit.onClick.AddListener(QuitGame);

        _options.onClick.AddListener(ShowOptions);
        _back.onClick.AddListener(BackToMainMenu);
        _soundOn.onValueChanged.AddListener(delegate { MuteOptionToggle(_soundOn); });
        _soundSlider.onValueChanged.AddListener(delegate { SoundController(_soundSlider); });
    }

    private void ResumeGame()
    {
        _pausePanel.SetActive(false);
    }
    private void ShowOptions()
    {
        _pausePanel.SetActive(false);
        _optionsPanel.SetActive(true);
    }
    private void QuitGame()
    {
        Application.Quit();
    }
    private void BackToMainMenu()
    {
        _pausePanel.SetActive(true);
        _optionsPanel.SetActive(false);
    }
    private void MuteOptionToggle(Toggle change)
    {
        if (_soundOn.isOn == false)
        {
            _soundOn.GetComponentInChildren<Text>().text = "Sound OFF";
            _mainMusic.mute = true;
        }
        else
        {
            _soundOn.GetComponentInChildren<Text>().text = "Sound ON";
            _mainMusic.mute = false;
        }
    }
    private void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
        private void SoundController(Slider soundSlider)
    {
        _mainMusic.volume = _soundSlider.value;
    }
}
