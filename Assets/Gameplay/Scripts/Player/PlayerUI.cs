using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public bool IsInMenu => _shopUI.gameObject.activeSelf || _isDisable;

    [SerializeField] private ShopUI _shopUI;
    [SerializeField] private GameObject _warpHint;
    [SerializeField] private Canvas _ui;

    private bool _isDisable;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            ToggleShopUI();
    }

    private void ToggleShopUI()
    {
        if (_shopUI.gameObject.activeSelf)
            _shopUI.gameObject.SetActive(false);
        else
            _shopUI.gameObject.SetActive(true);
    }

    public void Disable()
    {
        _ui.gameObject.SetActive(false);
        _isDisable = true;
    }

    public void EnableWarpHint()
    {
        _warpHint.SetActive(true);
    }
}
