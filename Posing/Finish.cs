using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Finish : PIButtonOnce
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

    }
}
