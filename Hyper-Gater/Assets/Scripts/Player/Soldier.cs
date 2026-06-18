using System.Collections;
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

    void OnEnable()
    {
        WeaponUpgrade.OnWeaponUpgrade += UpgradeReloadSpeed;
    }

    void OnDisable()
    {
        WeaponUpgrade.OnWeaponUpgrade -= UpgradeReloadSpeed;
    }

    // Important to use pooling here
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

    /// <summary>
    /// Multiplies the reloadSpeed using value from 0 - 1 (0% - 100%)
    /// <para>0.7f should equal 70% off</para>
    /// </summary>
    /// <param name="multiplier"></param>
    public void UpgradeReloadSpeed(float multiplier)
    {
        _reloadSpeed *= 1 - multiplier;
    }

}
