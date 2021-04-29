using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBox : MonoBehaviour,ITakeDamage
{
    [SerializeField] private int health = 10;
    public GameObject blueKey;
    public GameObject redKey;
    public GameObject goldKey;
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
        if (gameObject.CompareTag("BlueKeyBox"))
        {
            Instantiate(blueKey, transform.position, Quaternion.identity);
        }
        if (gameObject.CompareTag("RedKeyBox"))
            Instantiate(redKey, transform.position, Quaternion.identity);
        else Instantiate(goldKey, transform.position, Quaternion.identity);
    }
}
