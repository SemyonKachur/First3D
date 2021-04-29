using UnityEngine;

public class RedDoor : MonoBehaviour
{
    private PlayerController _playerController;
    private Animation _animation = null;
    private GameObject _player = null;
    private Vector3 _direction = Vector3.zero;

    private void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _animation = GetComponent<Animation>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        _direction.z = _player.transform.position.z - transform.position.z;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_playerController.RedKeyIsGrab == true)
        {
            if (other.CompareTag("Player"))
            {
                if (_direction.z < 0)
                    _animation.Play("DoorOpenForward");
                else
                    _animation.Play("DoorOpenBack");
            }
        }
    }
}
