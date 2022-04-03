using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class Enemy : MonoBehaviour
{
    public EnemyHealth Health => _health;

    [SerializeField] private EnemyWeapon _enemyWeapon;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minDistance;

    private Transform _target;
    private GameField _gameField;
    private EnemyHealth _health;

    public void Init(Transform target, GameField gameField)
    {
        _target = target;
        _gameField = gameField;

        _health = GetComponent<EnemyHealth>();
    }

    private void FixedUpdate()
    {
        float targetDistance = Vector2.Distance(_target.position, transform.position);

        transform.LookAt(_target.position);
        transform.Rotate(new Vector3(-180, -90, -90), Space.Self);

        Vector2 moveDirection = transform.GetForward2D() * _speed * Time.fixedDeltaTime;

        if(_gameField.IsInGameField(transform.GetPosition2D()))
            _enemyWeapon.Shoot(_collider);

        if (targetDistance <= _minDistance)
        {
            _rigidbody.AddForce(moveDirection * -2);
            return;
        }

        _rigidbody.AddForce(moveDirection);
    }
}
