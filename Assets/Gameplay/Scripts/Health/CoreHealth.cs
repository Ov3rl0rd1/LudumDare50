public class CoreHealth : Health
{
    public override void TakeDamage(float damage)
    {
        HealthChangedInvoke(damage);
    }

    protected override void Die()
    {
    }
}
