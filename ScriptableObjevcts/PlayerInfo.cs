using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class PlayerInfo : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField] private int _initMyActorNumber = 1;

    [SerializeField] private string _initMyName = "Player0";

    [SerializeField] private List<int> _initPlayerIDs = new List<int>() { 1, 2, 3, 4 };

    [SerializeField] private Dictionary<int, PIPlayer> _initPlayers = new Dictionary<int, PIPlayer>()
    {
        { 1, new PIPlayer("Player0", false, new Vector3[17], 0, 1) },
        { 2, new PIPlayer("Player1", false, new Vector3[17], 0, 1) },
        { 3, new PIPlayer("Player2", true, new Vector3[17], 0, 2) },
        { 4, new PIPlayer("Player3", false, new Vector3[17], 0, 3) }
    };


    /// <summary>
    /// localプレイヤーのActorNumber
    /// </summary>
    public int MyActorNumber { get; set; }

    /// <summary>
    /// localプレイヤーの名前
    /// </summary>
    public string MyName { get; set; }

    /// <summary>
    /// int ActorNumberとint ID(0 <= ID <= 3)を結びつける。
    /// </summary>
    public List<int> PlayerIdList { get; private set; }

    /// <summary>
    /// ActorNumberの名前、役職、体の回転を格納する。
    /// </summary>
    public Dictionary<int, PIPlayer> PlayerList { get; private set; }


    public void OnBeforeSerialize() { }

    public void OnAfterDeserialize()
    {
        MyActorNumber = _initMyActorNumber;
        MyName = _initMyName;
        PlayerIdList = _initPlayerIDs.Select(p => p).ToList();
        PlayerList = _initPlayers.ToDictionary(p => p.Key, p => p.Value);
    }


    public void Initialize()
    {
        MyActorNumber = 0;
        MyName = string.Empty;
        PlayerIdList.Clear();
        PlayerList.Clear();
    }

    public void Add(Player player)
    {
        Debug.Log(player.NickName);
        Debug.Log(player.ActorNumber);
        PlayerIdList.Add(player.ActorNumber);
        PlayerList.Add(player.ActorNumber, new PIPlayer(player.NickName));
    }

    public PIPlayer GetPlayerFromId(int id)
    {
        return PlayerList[PlayerIdList[id]];
    }

    public string GetMyName()
    {
        return PlayerList[MyActorNumber].Name;
    }

    public bool GetMyIsImpostor()
    {
        return PlayerList[MyActorNumber].IsImpostor;
    }

    public string GetMyRoll()
    {
        return PlayerList[MyActorNumber].GetRoll();
    }

    public Vector3[] GetMyRotation()
    {
        return PlayerList[MyActorNumber].Rotations;
    }

    public void SetMyRotation(Vector3[] rotations)
    {
        Debug.Log("<color=green> set my rotation </color>");

        PlayerList[MyActorNumber].SetRotations(rotations);
    }

    public void SetRotation(int actorNumber, Vector3[] rotatins)
    {
        Debug.Log("<color=green> set rotation </color>");

        PlayerList[actorNumber].SetRotations(rotatins);
    }

    public void VotedCountUp(int i)
    {
        PlayerList[PlayerIdList[i]].VotedCount++;
    }

    public int GetMyVotedCount()
    {
        return PlayerList[MyActorNumber].VotedCount;
    }

    public int GetMaxVotedCount()
    {
        return PlayerList.Select(p => p.Value.VotedCount).Max();
    }

    public bool GetIsImpostorMaxVoted()
    {
        int maxVotedCount = GetMaxVotedCount();

        return PlayerList.Where(p => p.Value.VotedCount == maxVotedCount).Where(p => p.Value.IsImpostor).Any();
    }

    public int GetMyVote()
    {
        return PlayerList[MyActorNumber].Vote;
    }

    public void SetMyVote(int v)
    {
        PlayerList[MyActorNumber].Vote = v;
    }
}
