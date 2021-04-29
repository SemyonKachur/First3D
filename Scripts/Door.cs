using UnityEngine;

public class Door : MonoBehaviour
{
    private Animation _animation = null;
    private GameObject _player = null;
    private Vector3 _direction = Vector3.zero;
    private GameObject _soundManagerObject;
    private SoundManager _soundManager = null;

    private void Start()
    {
        _animation = GetComponent<Animation>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        _soundManagerObject = GameObject.FindGameObjectWithTag("SoundManager");
    }
    private void Update()
    {
        _direction.z = _player.transform.position.z - transform.position.z;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _soundManagerObject.transform.position = transform.position;
            _soundManager.PlaySound(_soundManager.openDoorAudio);
            if (_direction.z<0)
                _animation.Play("DoorOpenForward");
            else
                _animation.Play("DoorOpenBack");
        }
        if (other.CompareTag("Enemy"))
        {
            _direction.z = other.gameObject.transform.position.z - transform.position.z;
            _soundManagerObject.transform.position = transform.position;
            _soundManager.PlaySound(_soundManager.openDoorAudio);
            if (_direction.z < 0)
                _animation.Play("DoorOpenForward");
            else
                _animation.Play("DoorOpenBack");
        }
    }
}
