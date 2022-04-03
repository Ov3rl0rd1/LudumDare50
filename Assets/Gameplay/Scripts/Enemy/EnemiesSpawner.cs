using System.Collections;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private EnemyWaves _enemyWaves;
    [SerializeField] private GameField _gameField;
    [SerializeField] private float _spawnRadius;

    private int _currentWave;
    private int _enemiesInCurrentWave;

    private void Start()
    {
        StartCoroutine(StartWaves());
    }

    private IEnumerator StartWaves()
    {
        yield return new WaitForSeconds(_enemyWaves.WavesDelay);

        Wave wave = _enemyWaves[_currentWave];
        if (wave == null)
        {
            _currentWave = 0;
            wave = _enemyWaves[_currentWave];
        }

        _currentWave++;

        StartCoroutine(SpawnWave(wave));

        StartCoroutine(StartWaves());
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        yield return new WaitForSeconds(wave.SpawnDelay);

        Vector2 randomPoint = Random.insideUnitCircle + Vector2.one * 2;
        Vector2 position = randomPoint * new Vector2(_gameField.FieldMaxX, _gameField.FieldMaxY);
        position *= _spawnRadius;
        _enemyManager.SpawnEnemy(wave.RandomEnemy, position);
        _enemiesInCurrentWave++;

        if (_enemiesInCurrentWave < wave.EnemiesCount)
            StartCoroutine(SpawnWave(wave));

        _enemiesInCurrentWave = 0;
        yield return null;
    }
}
