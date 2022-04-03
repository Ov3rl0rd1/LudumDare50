using UnityEngine;

public class CoreUI : MonoBehaviour
{
    [SerializeField] private Core _core;
    [SerializeField] private Timer _explosionTimer;
    [SerializeField] private ValueText _coreTemperature;

    private void OnEnable()
    {
        _core.OnTimerTick += _explosionTimer.UpdateValue;
        _core.OnChangeTemperature += _coreTemperature.UpdateValue;
    }

    private void OnDisable()
    {
        _core.OnTimerTick -= _explosionTimer.UpdateValue;
        _core.OnChangeTemperature -= _coreTemperature.UpdateValue;
    }
}
