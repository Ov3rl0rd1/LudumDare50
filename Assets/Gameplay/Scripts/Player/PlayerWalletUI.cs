using UnityEngine;
using UnityEngine.UI;

public class PlayerWalletUI : MonoBehaviour
{
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private Text _voidFragmentAmount;

    private void OnEnable()
    {
        _playerWallet.OnBalanceChanged += (value) => _voidFragmentAmount.text = value.ToString();
    }

    private void OnDisable()
    {
        _playerWallet.OnBalanceChanged -= (value) => _voidFragmentAmount.text = value.ToString();
    }
}
