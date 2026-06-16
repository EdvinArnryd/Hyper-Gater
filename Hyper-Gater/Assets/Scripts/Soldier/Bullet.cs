using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _lifeTime;
    private int _damage = 5;

    void Update()
    {
        transform.position += transform.forward * _bulletSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Health>().TakeDamage(_damage);

            // Important to use pooling here
            Destroy(gameObject);
        }
        else if(other.gameObject.CompareTag("Upgrade"))
        {
            other.gameObject.GetComponent<Upgrade>().Hit();

            // Important to use pooling here
            Destroy(gameObject);
        }
    }
}
