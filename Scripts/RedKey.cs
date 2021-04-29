using UnityEngine;

public class RedKey : MonoBehaviour
{
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("IF");
            _playerController.RedKeyIsGrab = true;
            Destroy(gameObject);
        }
    }

}
