using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public event Action<float> OnHealthChanged;
    public event Action OnDie;

    public float Value => _health;
    public float MaxValue => _maxHealth;

    [SerializeField] private float _maxHealth;

    private float _health;

    protected virtual void Awake()
    {
        _health = _maxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException();

        if (_health <= damage)
        {
            _health = 0;
            OnHealthChanged?.Invoke(_health);
            Die();
            return;
        }

        _health -= damage;
        OnHealthChanged?.Invoke(_health);
    }

    protected virtual void Die()
    {
        OnDie?.Invoke();
        OnDie = null;
        OnHealthChanged = null;
        Destroy(gameObject);
    }

    protected void Heal(float health)
    {
        if (health < 0)
            throw new ArgumentOutOfRangeException();

        _health += health;
        _health = Mathf.Clamp(_health, 0, _maxHealth);
        OnHealthChanged?.Invoke(_health);
    }

    protected void IncreaseMaxHealth(float multiplier)
    { 
        if(multiplier < 1)
            throw new ArgumentOutOfRangeException();

        _maxHealth *= multiplier;
    }

    protected void HealthChangedInvoke(float value)
    {
        OnHealthChanged?.Invoke(value);
    }
}
