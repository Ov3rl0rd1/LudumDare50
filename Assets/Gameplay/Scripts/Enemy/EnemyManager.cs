using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public event Action OnEnemyDie;

    [SerializeField] private Player _player;
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private GameField _gameField;

    public Enemy SpawnEnemy(Enemy enemy, Vector2 position)
    {
        enemy = Instantiate(enemy, position, Quaternion.identity).GetComponent<Enemy>();
        enemy.transform.parent = transform;
        enemy.Init(_player.transform, _gameField);
        enemy.Health.OnDie += OnEnemyDie;
        return enemy;
    }
}
