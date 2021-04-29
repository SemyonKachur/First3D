using UnityEngine;

public class GoldDoor : MonoBehaviour
{
    private PlayerController _playerController;
    private Animation _animation = null;
    private bool _obstacleProblem = true;
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
        if (_playerController.GoldKeyIsGrab == true & _obstacleProblem == false)
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
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Obstacle") == true)
        {
            _obstacleProblem = false;
        }
    }
}
