using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrades", menuName = "ScriptableObjects/Upgrades")]
public class Upgrades : ScriptableObject
{

    [SerializeField] private CoreUpgrade[] _coreUpgrades;
    [SerializeField] private HealthUpgrade[] _healthUpgrades;
    [SerializeField] private GunUpgrade[] _fighterUpgrades;


    [NonSerialized] private int _currentCoreUpgrade = 0;
    [NonSerialized] private int _currentHealthUpgrade = 0;
    [NonSerialized] private int _currentFighterUpgrade = 0;

    public CoreUpgrade GetNextCoreUpgrade()
    {
        CoreUpgrade element = GetElementInArray(_coreUpgrades, _currentCoreUpgrade);
        _currentCoreUpgrade++;
        return element;
    }

    public HealthUpgrade GetNextHealthUpgrade()
    {
        HealthUpgrade element = GetElementInArray(_healthUpgrades, _currentHealthUpgrade);
        _currentHealthUpgrade++;
        return element;
    }

    public GunUpgrade GetNextFighterUpgrade()
    {
        GunUpgrade element = GetElementInArray(_fighterUpgrades, _currentFighterUpgrade);
        _currentFighterUpgrade++;
        return element;
    }

    private T GetElementInArray<T>(T[] array, int index) where T : class
    {
        if (index > array.Length - 1 || index < 0)
            return null;

        return array[index];
    }
}

[Serializable]
public class CoreUpgrade : Upgrade
{
    public float CoolingSpeedMultiplier => _coolingSpeedMultiplier;

    [SerializeField] private float _coolingSpeedMultiplier;
}

[Serializable]
public class HealthUpgrade : Upgrade
{
    public float HealthMultiplier => _healthMultiplier;
    public float MaxHealthMultiplier => _maxHealthMultiplier;

    [SerializeField] private float _healthMultiplier;
    [SerializeField] private float _maxHealthMultiplier;
}

[Serializable]
public class GunUpgrade : Upgrade
{
    public float DamageMultiplier => _damageMultiplier;
    public float ShootDelayDivider => _shootDelayDivider;

    [SerializeField] private float _damageMultiplier;
    [SerializeField] private float _shootDelayDivider;
}

[Serializable]
public class WarpEngine : Upgrade
{ 
    
}
