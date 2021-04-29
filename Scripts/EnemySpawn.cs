using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemySpawn;
    public GameObject enemy;
    void Start()
    {
        Instantiate(enemy, enemySpawn.transform.position, Quaternion.identity);
    }
}
