using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private Shop _shop;
    [SerializeField] private UpgradeDescriptionUI _upgradeDescription;
    [SerializeField] private UpgradeUI _upgradeUIPrefab;
    [SerializeField] private Transform _upgradePanel;

    private List<UpgradeUI> _upgradeSlots = new List<UpgradeUI>();

    private void Start()
    {
        Init();
    }

    public void ApplyUpgrade(Upgrade upgrade)
    {
        if (_shop.BuyUpgrade(upgrade))
        {
            if (upgrade.IsInfinity == false)
            {
                UpdateUI();
            }
        }
    }

    private void Init()
    {
        for (int i = 0; i < 3; i++)
        {
            _upgradeSlots.Add(InstantiateUpgradeUI());
        }

        _upgradeSlots[0].Init(_shop.CoreUpgrade, _upgradeDescription); //TODO: fix this piece of shi...code
        _upgradeSlots[1].Init(_shop.HealthUpgrade, _upgradeDescription); //TODO: fix this piece of shi...code
        _upgradeSlots[2].Init(_shop.GunUpgrade, _upgradeDescription); //TODO: fix this piece of shi...code
    }

    private void UpdateUI()
    {
        //TODO: Visitor
        if(_upgradeSlots[0] != null) //TODO: fix this piece of shi...code
            _upgradeSlots[0].UpdatePanel(_shop.CoreUpgrade); //TODO: fix this piece of shi...code
        if (_upgradeSlots[1] != null) //TODO: fix this piece of shi...code
            _upgradeSlots[1]?.UpdatePanel(_shop.HealthUpgrade); //TODO: fix this piece of shi...code
        if (_upgradeSlots[2] != null) //TODO: fix this piece of shi...code
            _upgradeSlots[2]?.UpdatePanel(_shop.GunUpgrade); //TODO: fix this piece of shi...code

    }

    private UpgradeUI InstantiateUpgradeUI()
    {
        UpgradeUI upgradeUI = Instantiate(_upgradeUIPrefab, _upgradePanel).GetComponent<UpgradeUI>();
        upgradeUI.transform.SetParent(_upgradePanel, false);
        return upgradeUI;
    }
}
