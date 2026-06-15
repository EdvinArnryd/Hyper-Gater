using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _lifeTime;
    private int _damage = 5;

    void Update()
    {
        transform.position += new Vector3(0,0,_bulletSpeed * Time.deltaTime);
    }

    public int GetDamage()
    {
        return _damage;
    }
}
