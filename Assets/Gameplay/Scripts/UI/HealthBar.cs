using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Bar _healthBar;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.OnHealthChanged += UpdateHealthBar;
    }

    private void OnDisable()
    {
        _health.OnHealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar(float value)
    {
        _healthBar.SetValue(value, _health.MaxValue);
    }
}
