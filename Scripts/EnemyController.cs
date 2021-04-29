using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, ITakeDamage
{
    private GameObject player = null;
    public GameObject bullet = null;
    public GameObject enemyBulletSpawn = null;
    public float _distance = 0;
    public int _health = 40;
    public List<GameObject> drops;
    private bool enableToShoot = false;
    private float shootingTime = 3.0f;
    private AudioSource _enemyAudioSource = null;
    private GameObject _soundManagerObject;
    private SoundManager _soundManager = null;
    void Start()
    {
        player = GameObject.Find("Player");
        _enemyAudioSource = GetComponent<AudioSource>();
        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        _soundManagerObject = GameObject.FindGameObjectWithTag("SoundManager");
    }

     void Update()
    {
        _distance = Mathf.Sqrt((transform.position - player.transform.position).sqrMagnitude);
        if (_distance < 12)
        {
            transform.LookAt(player.transform.position);
        }
        shootingTime -= Time.deltaTime;
        if (shootingTime <= 0)
        {
            enableToShoot = true;
            shootingTime = 3.0f;
        }

    }
    public void TakeDamage(int damage)
    {
        _health -= damage;
        _enemyAudioSource.Play();
        if (_health <= 0)
        {
            _soundManagerObject.transform.position = transform.position;
            _soundManager.PlaySound(_soundManager.enemyDeath);
            Death();
        }
    }
    private void Death()
    {
        gameObject.SetActive(false);
        int index = Random.Range(0, drops.Count);
        Instantiate(drops[index], transform.position+Vector3.up, Quaternion.identity);
    }
    public void EnemyShooting()
    {
        if (enableToShoot == true)
        {
            enableToShoot = false;
            Instantiate(bullet, enemyBulletSpawn.transform.position, enemyBulletSpawn.transform.rotation, transform.parent);
        }
    }
}
