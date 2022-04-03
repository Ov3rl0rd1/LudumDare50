using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider;

    private void Awake()
    {
        _volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.5f) * _volumeSlider.maxValue;
    }

    public void OnValueChanged()
    {
        PlayerPrefs.SetFloat("Volume", _volumeSlider.value / _volumeSlider.maxValue);
        PlayerPrefs.Save();
    }
}
