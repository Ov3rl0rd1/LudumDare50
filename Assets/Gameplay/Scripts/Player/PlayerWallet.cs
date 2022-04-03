using System;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    public event Action<float> OnBalanceChanged;

    public int Balance => _balance;

    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private int _enemyCost;

    private int _balance;

    public void DecreaseBalance(int value)
    {
        if (value < 0 || value > _balance)
            throw new InvalidOperationException();

        _balance -= value;
        OnBalanceChanged?.Invoke(_balance);
    }

    private void OnEnable()
    {
        _enemyManager.OnEnemyDie += OnEnemyDie;
    }

    private void OnDisable()
    {
        _enemyManager.OnEnemyDie -= OnEnemyDie;
    }

    private void OnEnemyDie()
    {
        _balance += _enemyCost;
        OnBalanceChanged?.Invoke(_balance);
    }
}
