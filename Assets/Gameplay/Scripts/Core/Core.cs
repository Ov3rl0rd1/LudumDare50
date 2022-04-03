using System;
using UnityEngine;

public class Core : MonoBehaviour
{
    public event Action<float> OnTimerTick;
    public event Action<float> OnChangeTemperature;

    [SerializeField] private Player _player;
    [SerializeField] private CoreHealth _coreHealth;
    [SerializeField] private Animator _coreAnimator;
    [SerializeField] private float _maxTemperature;
    [SerializeField] private float _coolingSpeed;
    [SerializeField] private float _timeToExplosion;
    [SerializeField] private float _warpEngineStartTime;

    private float _coreTemperature;
    private float _explosionTimer;

    public void ApplyUpgrage(CoreUpgrade upgrade)
    {
        _coolingSpeed *= upgrade.CoolingSpeedMultiplier;
    }

    private void Awake()
    {
        _explosionTimer = _timeToExplosion;
        OnChangeTemperature?.Invoke(_coreTemperature);
    }

    private void OnEnable()
    {
        _coreHealth.OnHealthChanged += OnTakeDamage;
    }

    private void OnDisable()
    {
        _coreHealth.OnHealthChanged -= OnTakeDamage;
    }

    private void FixedUpdate()
    {
        if (_explosionTimer > 0)
        {
            _explosionTimer -= Time.fixedDeltaTime;
            OnTimerTick?.Invoke(_explosionTimer);

            if (_warpEngineStartTime >= _explosionTimer)
                _player.EnableWarpEngine();

        }
        else
            ExplodeCore();

        if (_coreTemperature >= 1)
        {
            _coreTemperature -= Time.fixedDeltaTime * _coolingSpeed;
            OnChangeTemperature?.Invoke(_coreTemperature);
        }
    }

    private void OnTakeDamage(float damage)
    {
        _coreTemperature += damage * 50;
        OnChangeTemperature?.Invoke(_coreTemperature);

        if (_coreTemperature > _maxTemperature)
            ExplodeCore();
    }

    private void ExplodeCore()
    {
        _coreAnimator.SetTrigger("BlowUp");
    }
}
