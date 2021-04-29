using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurelController : MonoBehaviour, ITakeDamage
{
    private GameObject player = null;
    public GameObject bullet = null;
    public GameObject enemyBulletSpawn = null;
    private float _distance = 0;
    public int _health = 100;
    public List<GameObject> drops;
    private bool enableToShoot = false;
    private float shootingTime = 1.0f;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        
        _distance = Mathf.Sqrt((transform.position - player.transform.position).sqrMagnitude);
        if (_distance < 15)
        {
            transform.LookAt(player.transform.position);
            EnemyShooting();
        }
        shootingTime -= Time.deltaTime;
        if (shootingTime <= 0)
        {
            enableToShoot = true;
            shootingTime = 1.0f;
        }

    }
    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Death();
        }
    }
    private void Death()
    {
        Destroy(gameObject);
        int index = Random.Range(0, drops.Count);
        Instantiate(drops[index], transform.position + Vector3.up, Quaternion.identity);
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
