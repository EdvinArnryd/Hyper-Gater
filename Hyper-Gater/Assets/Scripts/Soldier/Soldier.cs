using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private GameObject _bulletPoint;

    [SerializeField] private float _reloadSpeed = 2;
    [SerializeField] private float _bulletDuration = 5;

    void Start()
    {
        StartCoroutine(SpawnBullet());
    }

    IEnumerator SpawnBullet()
    {
        Bullet bullet = Instantiate(_bulletPrefab);
        bullet.transform.position = _bulletPoint.transform.position;
        StartCoroutine(DestroyBullet(bullet));
        yield return new WaitForSeconds(_reloadSpeed);
        StartCoroutine(SpawnBullet());
    }

    IEnumerator DestroyBullet(Bullet bullet)
    {
        yield return new WaitForSeconds(_bulletDuration);
        if(bullet)
            Destroy(bullet.gameObject);
    }

}
