using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class PIButtonOnlyOne : PIButton
{
    /// <summary>
    /// すべてのボタンをリセットするイベント
    /// </summary>
    [SerializeField] private GameEvent _buttonEvent;


    public void Update()
    {
        if (!IsPressed) { return; }
        _unityEvent.Invoke();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (IsPressed)
        {
            ButtonReset();
            return;
        }

        _buttonEvent.Raise();

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