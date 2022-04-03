using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private Player _player;

    public void ApplyUpgrade(HealthUpgrade upgrade)
    {
        Heal(upgrade.HealthMultiplier * MaxValue);
        IncreaseMaxHealth(upgrade.MaxHealthMultiplier);
    }

    protected override void Die()
    {
        _player.PlayerDead();
    }
}
