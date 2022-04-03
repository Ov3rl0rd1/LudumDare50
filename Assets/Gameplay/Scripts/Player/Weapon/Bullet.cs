using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    public Collider2D Collider => _collider;

    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;

    private Vector2 _direction;
    private Collider2D _collider;
    private float _damage;

    public void Init(float damage)
    {
        _damage = damage;
    }

    private void Awake()
    {
        _direction = transform.GetForward2D();
        _collider = GetComponent<Collider2D>();
    }
    private void FixedUpdate()
    {
        Vector2 direction = _direction * _speed;
        transform.position += new Vector3(direction.x, direction.y, 0);

        if (_lifeTime > 0)
            _lifeTime -= Time.fixedDeltaTime;
        else
            Destroy(gameObject);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet))
            return;

        if (collision.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
}
