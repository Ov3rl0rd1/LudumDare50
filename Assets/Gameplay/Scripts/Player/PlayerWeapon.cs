using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private DefaultGun _gun;

    public void Shoot(Collider2D playerCollider)
    {
        if (_gun.CanShoot)
        {
            Bullet bullet = _gun.Shoot();
            Physics2D.IgnoreCollision(playerCollider, bullet.Collider, true);
        }
    }
}
