using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeDescriptionUI : MonoBehaviour
{
    [SerializeField] private ShopUI _shopUI;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _cost;
    [SerializeField] private Button _buyButton;

    private Upgrade _currentUpgrade;

    public void OnUpgradeSelected(Upgrade upgrade)
    {
        if (upgrade == _currentUpgrade)
            return;

        _currentUpgrade = upgrade;

        _description.text = upgrade.Description;
        _cost.text = upgrade.Cost.ToString();
        _buyButton.onClick.RemoveAllListeners();
        _buyButton.onClick.AddListener(() => { _shopUI.ApplyUpgrade(_currentUpgrade); });
    }

    public void Clear()
    {
        _currentUpgrade = null;

        _description.text = "";
        _cost.text = "";
        _buyButton.onClick.RemoveAllListeners();
    }
}
