using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(Image))]

public class PIButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    protected Image _image;
    protected RectTransform _transform;


    /// <summary>
    /// ボタンが押されたときscale *= Pressed Scaleされる
    /// </summary>
    [SerializeField] protected float _pressedScale = 0.9f;

    /// <summary>
    /// ボタンが押されたときPressed Spriteに変更する
    /// </summary>
    [SerializeField] protected Sprite _pressedSprite;

    /// <summary>
    /// ボタンが押されたときPressed Materialに変更する
    /// </summary>
    [SerializeField] protected Material _pressedMaterial;

    /// <summary>
    /// ボタンが押されたときImage.color -= new Color(Pressed Color, Pressed Color, Pressed Color) される
    /// </summary>
    [SerializeField] protected float _pressedColor = 0f;

    /// <summary>
    /// クリックした際に呼び出される関数
    /// </summary>
    [SerializeField] protected UnityEvent _unityEvent;


    protected PIScale _piScale;

    protected Sprite _defaultSprite;

    protected Material _defaultMaterial;

    protected PIColor _piColor;


    public bool IsPressed { get; protected set; }


    protected virtual void Awake()
    {
        _image = GetComponent<Image>();
        _transform = GetComponent<RectTransform>();

        _piScale = new PIScale(_transform.localScale, _pressedScale);
        _piColor = new PIColor(_image.color, _pressedColor);
        _defaultMaterial = _image.material;
        _defaultSprite = _image.sprite;
    }

    private void OnEnable() 
    {
        IsPressed = false; 
    }

    private void OnDisable()
    {
        _unityEvent.RemoveAllListeners();
    }

    public virtual void OnPointerDown(PointerEventData eventData) 
    {
        _transform.DOScale(_piScale.ChangedScale, 0.24f).SetEase(Ease.OutCubic);
    }

    public virtual void OnPointerUp(PointerEventData eventData) 
    {
        _transform.DOScale(_piScale.DefaultScale, 0.24f).SetEase(Ease.OutCubic);
    }

    /// <summary>
    /// クリックされるとボタンは押されたままになる。
    /// もう一度押すと戻る。
    /// </summary>
    /// <param name="eventData"></param>
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (IsPressed) 
        {
            ButtonReset();
            return;
        }

        IsPressed = true;
        if (_pressedSprite != null) { _image.sprite = _pressedSprite; }
        if (_pressedMaterial != null) { _image.material = _pressedMaterial; }
        _image.color = _piColor.ChangedColor;

        _unityEvent?.Invoke();
    }

    public virtual void ButtonReset()
    {
        IsPressed = false;
        _image.sprite = _defaultSprite;
        _image.material = _defaultMaterial;
        _image.color = _piColor.DefaultColor;
    }
}

