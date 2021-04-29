using UnityEngine;

public class DynamiteController : MonoBehaviour
{
    private PlayerController _playerController = null;
    [SerializeField] private UIScript _playerUI = null;
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
            _playerController.bombAmmo++;
            _playerUI = GameObject.FindGameObjectWithTag("PlayerUI").GetComponent<UIScript>(); 
            _playerUI.BombChnge();
            _soundManagerObject.transform.position = transform.position;
            _soundManager.PlaySound(_soundManager.takeBombAudio);
            Destroy(gameObject);
        }
    }
}
