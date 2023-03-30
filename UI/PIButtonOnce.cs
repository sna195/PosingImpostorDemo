using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PIButtonOnce : PIButton
{
    public override void OnPointerUp(PointerEventData eventData)
    {
        if (IsPressed) return;
        base.OnPointerUp(eventData);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (IsPressed) return;
        base.OnPointerDown(eventData);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (IsPressed) { return; }

        IsPressed = true;
        if (_pressedSprite != null) { _image.sprite = _pressedSprite; }
        if (_pressedMaterial != null) { _image.material = _pressedMaterial; }
        _image.color = _piColor.ChangedColor;

        _unityEvent?.Invoke();
    }
}
