using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _selectButton;

    private Upgrade _currentUpgrade;
    private UpgradeDescriptionUI _upgradeDescription;

    public void Init(Upgrade upgrade, UpgradeDescriptionUI upgradeDescription)
    {
        if (upgrade == null || upgradeDescription == null)
            throw new System.ArgumentNullException();

        _upgradeDescription = upgradeDescription;

        UpdatePanel(upgrade);
    }

    public void UpdatePanel(Upgrade upgrade)
    {
        if (upgrade == _currentUpgrade)
            return;

        if (upgrade == null)
        {
            _upgradeDescription.Clear();
            Destroy(gameObject);
            return;
        }

        _currentUpgrade = upgrade;
        _upgradeDescription.Clear();

        _name.text = upgrade.Name;
        _icon.sprite = upgrade.Icon;
        _selectButton.onClick.AddListener(delegate { _upgradeDescription.OnUpgradeSelected(_currentUpgrade);});
    }
}
