using System;
using TMPro;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private int _startValue = 50;
    [SerializeField] private float _upgradeMultiplier = 0.1f; // 10%

    public static event Action<float> OnWeaponUpgrade;
    private int _currentValue;

    void Start()
    {
        _currentValue = _startValue;
        UpdateText();
    }

    public void Hit()
    {
        _currentValue--;
        UpdateText();
        if(_currentValue <= 0)
        {
            OnWeaponUpgrade?.Invoke(_upgradeMultiplier);
            Destroy(gameObject);
        }
    }

    private void UpdateText()
    {
        _text.text = _currentValue.ToString();
    }
}
