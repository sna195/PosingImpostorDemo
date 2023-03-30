using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PIButtonImpostor : PIButtonOnce
{
    /// <summary>
    /// プレイヤーの情報を持つアセット
    /// </summary>
    [SerializeField] PlayerInfo _playerInfo;

    /// <summary>
    /// インポスターではない場合操作できない
    /// </summary>
    /// <param name="eventData"></param>
    public override void OnPointerUp(PointerEventData eventData)
    {
        if (!_playerInfo.GetMyIsImpostor()) { return; }
        base.OnPointerUp(eventData);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (!_playerInfo.GetMyIsImpostor()) { return; }
        base.OnPointerDown(eventData);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (!_playerInfo.GetMyIsImpostor()) { return; }
        base.OnPointerClick(eventData);
    }
}
