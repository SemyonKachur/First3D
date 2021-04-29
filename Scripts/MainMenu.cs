using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] private GameObject _menuPanel = null;
    [SerializeField] private Button _startGame = null;
    [SerializeField] private Button _options = null;
    [SerializeField] private Button _quit = null;
    [Header("Options")]
    [SerializeField] private GameObject _optionsPanel = null;
    [SerializeField] private Button _back = null;
    [SerializeField] private Toggle _soundOn = null;
    [SerializeField] private Slider _soundSlider = null;
    [SerializeField] private AudioSource _mainMusic = null;

    private void Awake()
    {
        _mainMusic = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioSource>();
        _startGame.onClick.AddListener(StartGame);
        _options.onClick.AddListener(ShowOptions);
        _quit.onClick.AddListener(QuitGame);
        _back.onClick.AddListener(BackToMainMenu);
        _soundOn.onValueChanged.AddListener(delegate { MuteOptionToggle(_soundOn); });
        _soundSlider.onValueChanged.AddListener(delegate { SoundController(_soundSlider); });
    }
    
    private void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    private void ShowOptions()
    {
        _menuPanel.SetActive(false);
        _optionsPanel.SetActive(true);
    }
    private void QuitGame()
    {
        Application.Quit();
    }
    private void BackToMainMenu()
    {
        _menuPanel.SetActive(true);
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
    private void SoundController(Slider soundSlider)
    {
        _mainMusic.volume = _soundSlider.value;
    }
}
