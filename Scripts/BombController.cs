using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _pushSpeed = -50000f;
    [SerializeField] private float _torqueSpeed = 5f;
    public ParticleSystem explosion = null;
    private Rigidbody _rigidbody = null;
    private GameObject[] enemies = new GameObject[30];
    private GameObject _soundManagerObject;
    private SoundManager _soundManager = null;
    private List<GameObject> damageEnemies = new List<GameObject>();
    private float _distance = 0;
    private float maxTorque = 100;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(transform.forward * _speed, ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Acceleration);
        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        _soundManagerObject = GameObject.FindGameObjectWithTag("SoundManager");
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _soundManagerObject.transform.position = transform.position;
            _soundManager.PlaySound(_soundManager.bombDetonate);
            Destroy(gameObject);
            Instantiate(explosion,transform.position,Quaternion.identity);
            explosion.Play();
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemies.Length; i++)
            {
                _distance = Mathf.Sqrt((transform.position - enemies[i].transform.position).sqrMagnitude);
                if (_distance <= 10)
                {
                    damageEnemies.Add(enemies[i]);
                }
            }

            for (int j = 0; j < damageEnemies.Count; j++)
            {
                damageEnemies[j].GetComponent<ITakeDamage>().TakeDamage(Random.Range(15, 30));
                Vector3 push = (damageEnemies[j].transform.position - transform.position).normalized;
                _rigidbody = damageEnemies[j].GetComponent<Rigidbody>();
                _rigidbody.AddForce(push * _pushSpeed, ForceMode.Impulse);
            }
        }
    }

}
