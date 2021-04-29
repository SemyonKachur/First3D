using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _panel = null;
    [SerializeField] private GameObject _optionsPanel = null;
    [SerializeField] private GameObject _winPanel = null;
    [SerializeField] private GameObject _loosePanel = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _panel.SetActive(true);
            _winPanel.SetActive(false);
            _loosePanel.SetActive(false);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if(_panel.active == false & _optionsPanel.active == false)
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
