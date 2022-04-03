using UnityEngine;

public class DefaultGun : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _shootDelay;
    [SerializeField] private float _damage;

    public virtual bool CanShoot => _shootTimer <= 0;

    private float _shootTimer;

    public virtual Bullet Shoot()
    {
        if (CanShoot == false)
            throw new System.InvalidOperationException();

        _shootTimer = _shootDelay;
        _audioSource.Play();
        return SpawnBullet();
    }

    public void ApplyUpgrade(GunUpgrade upgrade)
    {
        _damage *= upgrade.DamageMultiplier;
        _shootDelay /= upgrade.ShootDelayDivider;
    }

    protected virtual void Update()
    {
        if (_shootTimer > 0)
            _shootTimer -= Time.deltaTime;
    }

    protected virtual Bullet SpawnBullet()
    {
        Bullet bullet = Instantiate(_bullet.gameObject, transform).GetComponent<Bullet>();
        bullet.transform.parent = null;
        bullet.Init(_damage);
        return bullet;
    }
}
