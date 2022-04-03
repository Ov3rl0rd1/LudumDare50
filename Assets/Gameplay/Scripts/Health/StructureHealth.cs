using UnityEngine;

public class StructureHealth : Health
{
    [SerializeField] private GameObject _explosionEffect;

    protected override void Die()
    {
        GameObject explosion = Instantiate(_explosionEffect, transform);
        explosion.transform.parent = null;
        base.Die();
    }
}
