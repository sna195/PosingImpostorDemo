using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PIButtonAlwaysOne : PIButton
{
    /// <summary>
    /// すべてのボタンをリセットするイベント
    /// </summary>
    [SerializeField] private GameEvent _buttonEvent;


    public override void OnPointerClick(PointerEventData eventData)
    {
        if (IsPressed) { return; }

        _buttonEvent.Raise();

        _unityEvent?.Invoke();

        IsPressed = true;
        if (_pressedSprite != null) { _image.sprite = _pressedSprite; }
        if (_pressedMaterial != null) { _image.material = _pressedMaterial; }
        _image.color = _piColor.ChangedColor;
    }

    public override void ButtonReset()
    {
        if (!IsPressed) { return; }

        base.ButtonReset();
    }
}
