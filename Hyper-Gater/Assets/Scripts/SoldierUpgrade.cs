using System;
using TMPro;
using UnityEngine;

public class SoldierUpgrade : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private int _startValue = 10;
    private int _currentValue;

    public static event Action<int> OnSoldierUpgrade;

    void Start()
    {
        _currentValue = _startValue;
        UpdateText();
    }

    public void Hit()
    {
        _currentValue++;
        UpdateText();
    }

    private void UpdateText()
    {
        _text.text = _currentValue.ToString();
    }
}
