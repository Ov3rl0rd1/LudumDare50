using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWaves", menuName = "ScriptableObjects/Enemy waves")]
public class EnemyWaves : ScriptableObject
{
    public float WavesDelay => _wavesDelay;
    public int WavesCount => _enemyWaves.Length;

    [SerializeField] private Wave[] _enemyWaves;
    [SerializeField] private float _wavesDelay;

    public Wave this[int index] => index < _enemyWaves.Length && index >= 0 ? _enemyWaves[index] : null;
}

[System.Serializable]
public class Wave
{
    public Enemy RandomEnemy => _enemiesPrefabs[Random.Range(0, _enemiesPrefabs.Length)];
    public float SpawnDelay => _spawnDelay;
    public int EnemiesCount => _enemiesCount;

    [SerializeField] private Enemy[] _enemiesPrefabs;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private int _enemiesCount;
}
