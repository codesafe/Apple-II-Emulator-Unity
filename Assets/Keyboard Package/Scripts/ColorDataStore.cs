using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDataStore : MonoBehaviour
{
    [SerializeField] Color borderColor;
    [SerializeField] Color fillColor;
    [SerializeField] Color textColor;
    [SerializeField] Color actionTextColor;

    static Color _borderColor;
    static Color _fillColor;
    static Color _textColor;
    static Color _actionTextColor;

    private void Awake()
    {
        _borderColor = borderColor;
        _fillColor = fillColor;
        _textColor = textColor;
        _actionTextColor = actionTextColor;
    }

    public static Color GetKeyboardBorderColor() { return _borderColor; }
    public static Color GetKeyboardFillColor() { return _fillColor; }
    public static Color GetKeyboardTextColor() { return _textColor; }
    public static Color GetKeyboardActionTextColor() { return _actionTextColor; }
}
