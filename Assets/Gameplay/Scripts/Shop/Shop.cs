using UnityEngine;

public class Shop : MonoBehaviour
{
    public CoreUpgrade CoreUpgrade => _coreUpgrade;
    public HealthUpgrade HealthUpgrade => _healthUpgrade;
    public GunUpgrade GunUpgrade => _fighterUpgrade;

    [SerializeField] private Upgrades _upgrades;
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private Core _core;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private DefaultGun _playerGun;

    private CoreUpgrade _coreUpgrade;
    private HealthUpgrade _healthUpgrade;
    private GunUpgrade _fighterUpgrade;

    private void Awake()
    {
        _coreUpgrade = _upgrades.GetNextCoreUpgrade();
        _healthUpgrade = _upgrades.GetNextHealthUpgrade();
        _fighterUpgrade = _upgrades.GetNextFighterUpgrade();
    }

    public bool BuyUpgrade(Upgrade upgrade)
    {
        if (_playerWallet.Balance < upgrade.Cost)
            return false;

        if (upgrade is CoreUpgrade)
        {
            _core.ApplyUpgrage((CoreUpgrade)upgrade);
            _coreUpgrade = _upgrades.GetNextCoreUpgrade();
        }
        else if (upgrade is HealthUpgrade)
        {
            _playerHealth.ApplyUpgrade((HealthUpgrade)upgrade);
            _healthUpgrade = _upgrades.GetNextHealthUpgrade();
        }
        else if (upgrade is GunUpgrade)
        {
            _playerGun.ApplyUpgrade((GunUpgrade)upgrade);
            _fighterUpgrade = _upgrades.GetNextFighterUpgrade();
        }
        else
            throw new System.NotImplementedException();

        _playerWallet.DecreaseBalance(upgrade.Cost);
        return true;
    }
}
