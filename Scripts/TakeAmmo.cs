using UnityEngine;

public class TakeAmmo : MonoBehaviour
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
            _playerController.ammo += 10;
            _playerUI = GameObject.FindGameObjectWithTag("PlayerUI").GetComponent<UIScript>();
            _playerUI.AmmoChnge();
            _soundManagerObject.transform.position = transform.position;
            _soundManager.PlaySound(_soundManager.takeAmmoAudio);
            Destroy(gameObject);
        }
    }
}
