using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameField _gameField;
    [SerializeField] private PlayerUI _playerUI;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _speed;

    private void OnValidate()
    {
        if (_rigidbody == null)
            Debug.LogError("PlayerMovement: _rigidbody is null!");
    }

    private void FixedUpdate()
    {
        if (_playerUI.IsInMenu)
            return;

        Move();
    }

    private void Move()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        Vector2 direction = vertical * transform.GetForward2D();
        direction *= _speed * Time.fixedDeltaTime;

        float zRotation = -horizontal * _rotationSpeed * Time.fixedDeltaTime;
        transform.Rotate(0, 0, zRotation);

        _rigidbody.AddForce(direction);
        transform.position = _gameField.ClampPosition(transform.GetPosition2D());
    }
}
