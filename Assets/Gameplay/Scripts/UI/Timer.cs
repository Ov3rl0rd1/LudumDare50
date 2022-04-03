using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerValue;

    public void UpdateValue(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time % 60;

        string min = minutes < 10 ? "0" + minutes : minutes.ToString();
        string sec = seconds < 10 ? "0" + seconds : seconds.ToString();

        _timerValue.text = $"{min}:{sec}";
    }
}
