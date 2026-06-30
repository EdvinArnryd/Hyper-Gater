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

            ObjectPool.Instance.DeSpawn(gameObject);
        }
        else if(other.gameObject.CompareTag("SoldierUpgrade"))
        {
            other.gameObject.GetComponent<SoldierUpgrade>().Hit();

            ObjectPool.Instance.DeSpawn(gameObject);
        }
        else if(other.gameObject.CompareTag("WeaponUpgrade"))
        {
            other.gameObject.GetComponent<WeaponUpgrade>().Hit();

            ObjectPool.Instance.DeSpawn(gameObject);
        }
        else if(other.gameObject.CompareTag("Wall"))
        {
            ObjectPool.Instance.DeSpawn(gameObject);
        }
    }
}
