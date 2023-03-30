using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIColor
{
    public Color DefaultColor { get; private set; }

    public Color ChangedColor { get; private set; }

    public PIColor(Color defaultColor, Color colorOffset)
    {
        DefaultColor = defaultColor;
        ChangedColor = defaultColor - colorOffset;
    }

    public PIColor(Color defaultColor, float colorOffset)
    {
        DefaultColor = defaultColor;
        ChangedColor = defaultColor - new Color(colorOffset, colorOffset, colorOffset, 0);
    }
}