using UnityEngine;

public class SettingsLoader : MonoBehaviour
{
    private void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("Volume", 0.5f);
        Application.targetFrameRate = Mathf.Clamp(Screen.currentResolution.refreshRate, 60, 240);
    }
}
