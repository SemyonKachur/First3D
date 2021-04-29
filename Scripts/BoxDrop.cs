using System.Collections.Generic;
using UnityEngine;

public class BoxDrop : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int health = 10;
    public List<GameObject> drops;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }
    private void Death()
    {
        Destroy(gameObject);
        int index = Random.Range(0, drops.Count);
        Instantiate(drops[index],transform.position,Quaternion.identity);
    }
}
