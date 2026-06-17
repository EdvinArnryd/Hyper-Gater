using UnityEngine;

[CreateAssetMenu(fileName = "SoldierStats", menuName = "ScriptableObjects/Soldier")]
public class SoldierStats : ScriptableObject
{
    [SerializeField] private float _startReloadSpeed;
    [SerializeField] private int _bulletDamage;
    
    private float _reloadSpeed;

    void OnEnable()
    {
        _reloadSpeed = _startReloadSpeed;
    }

    public float GetReloadSpeed()
    {
        return _reloadSpeed;
    }

    public int GetBulletDamage()
    {
        return _bulletDamage;
    }

    public void ReloadUpgrade()
    {
        _reloadSpeed /=2;
    }
}
