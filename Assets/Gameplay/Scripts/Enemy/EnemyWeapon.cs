using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private DefaultGun _enemyGun;

    public void Shoot(Collider2D enemyCollider)
    {
        if (_enemyGun.CanShoot)
        {
            Bullet bullet = _enemyGun.Shoot();
            Physics2D.IgnoreCollision(enemyCollider, bullet.Collider, true);
        }
    }
}
