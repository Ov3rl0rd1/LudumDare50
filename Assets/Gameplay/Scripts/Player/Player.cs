using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerWeapon _playerWeapon;
    [SerializeField] private Collider2D _playerCollider;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private PlayerUI _playerUI;

    private bool _canStartWarpEngine;

    private void Update()
    {
        if (Input.GetMouseButton(0) && _playerUI.IsInMenu == false)
            _playerWeapon.Shoot(_playerCollider);
        if (Input.GetKeyDown(KeyCode.R) && _canStartWarpEngine)
            StartWarpEngine();
    }

    public void PlayerDead()
    {
        _playerUI.Disable();
        _playerAnimator.SetTrigger("Dead");
    }

    public void EnableWarpEngine()
    {
        _canStartWarpEngine = true;
        _playerUI.EnableWarpHint();
    }

    private void StartWarpEngine()
    {
        _playerUI.Disable();
        _playerAnimator.SetTrigger("Warp");
    }
}
