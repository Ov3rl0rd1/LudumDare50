using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] private float _lifeTime;

    private float lifeTimer;

    protected override void Awake()
    {
        base.Awake();
        lifeTimer = _lifeTime;
    }

    private void FixedUpdate()
    {
        if (lifeTimer > 0)
            lifeTimer -= Time.fixedDeltaTime;
        else
            Die();
    }

    protected override void Die()
    {
        GameObject explosion = Instantiate(_explosionEffect, transform);
        explosion.transform.parent = null;
        base.Die();
    }
}
