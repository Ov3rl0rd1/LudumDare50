using System;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public float Value => _value;

    [SerializeField] private Image _valueImage;

    private float _value;

    public void SetValue(float value, float maxValue)
    {
        if (value < 0)
            throw new InvalidOperationException();

        _value = value;

        _valueImage.fillAmount = _value / maxValue;
    }
}
