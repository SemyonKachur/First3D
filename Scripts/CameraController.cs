using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject _desiredCameraPosition;
    [SerializeField] private Vector3 _offsetCameraLook = Vector3.zero;
    [SerializeField] private float _offsetAngle = 23.5f;
    private GameObject _player = null;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
           void Update()
    {
        transform.rotation = Quaternion.Euler(_offsetAngle,_player.transform.rotation.eulerAngles.y,_player.transform.rotation.eulerAngles.z);
        transform.position = _desiredCameraPosition.transform.position;
    }
}
