using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PIButtonNoHold : PIButton
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        _unityEvent?.Invoke();
    }
}
