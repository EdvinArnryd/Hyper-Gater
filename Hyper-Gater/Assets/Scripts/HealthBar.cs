using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void UpdateHealthBar( int currentHealth, int maxHealth)
    {
        _slider.value = (float)currentHealth / maxHealth;
    }
}
