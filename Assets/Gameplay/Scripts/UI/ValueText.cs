using UnityEngine;
using TMPro;

public class ValueText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private string _defaultValue;

    private void Awake()
    {
        _defaultValue = _text.text;
    }

    public void UpdateValue(float value)
    {
        _text.text = ((int)value).ToString() + _defaultValue;
    }
}
