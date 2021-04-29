using UnityEngine;

public class TakeHealth : MonoBehaviour
{
    private PlayerController _playerController = null;
    private UIScript _playerUI = null;
    private GameObject _soundManagerObject;
    private SoundManager _soundManager = null;
    private void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        _soundManagerObject = GameObject.FindGameObjectWithTag("SoundManager");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_playerController.health < 80)
            {
                _playerController.health += 20;
            }
            else
            {
                _playerController.health = 100;
            }
            _playerUI = GameObject.FindGameObjectWithTag("PlayerUI").GetComponent<UIScript>();
            _playerUI.HealhtChange();
            _soundManagerObject.transform.position = transform.position;
            _soundManager.PlaySound(_soundManager.healAudio);
            Destroy(gameObject);
        }
    }
}
