using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIScale
{
    public Vector3 DefaultScale { get; private set; }

    public Vector3 ChangedScale { get; private set; }

    public PIScale(Vector3 defaultScale, float scaleOffset)
    {
        DefaultScale = defaultScale;
        ChangedScale = defaultScale * scaleOffset;
    }
}
