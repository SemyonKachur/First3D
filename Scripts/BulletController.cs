using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    private Rigidbody rigidbody = null;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rigidbody.AddForce(transform.forward * _speed, ForceMode.Impulse);
    }

    public void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<ITakeDamage>().TakeDamage(Random.Range(5,15));
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            other.gameObject.GetComponent<ITakeDamage>().TakeDamage(Random.Range(5, 15));
        }
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<ITakeDamage>().TakeDamage(Random.Range(5, 15));
            Debug.Log(other.gameObject.GetComponent<PlayerController>().health);
        }
        if (other.gameObject.CompareTag("BlueKeyBox")|| other.gameObject.CompareTag("RedKeyBox") || other.gameObject.CompareTag("GoldKeyBox"))
        {
            other.gameObject.GetComponent<ITakeDamage>().TakeDamage(Random.Range(5, 15));
        }

    }
   
}
