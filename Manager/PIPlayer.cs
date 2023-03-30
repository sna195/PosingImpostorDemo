using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PIPlayer
{
    public string Name { get; private set; }

    public bool IsImpostor { get; set; }

    public Vector3[] Rotations { get; private set; }

    public int VotedCount { get; set; }

    public int Vote { get; set; }


    public PIPlayer()
    {
        Name = string.Empty;
        IsImpostor = false;
        Rotations = new Vector3[new RotateParts().RotateCount];
        VotedCount = 0;
        Vote = 0;
    }

    public PIPlayer(string name) : this()
    {
        Name = name;
    }

    public PIPlayer(string name, bool isImpostor): this(name)
    {
        Name = name;
        IsImpostor = isImpostor;
    }

    public PIPlayer(string name, bool isImpostor, Vector3[] rotations, int voteCount) : this(name, isImpostor)
    {
        Assert.IsTrue(rotations.Length == new RotateParts().RotateCount, "PlayerInfo.Rotationsに与えられたVector3[]の長さがRotateParts().RotateCountと一致しない");

        Rotations = rotations;
        VotedCount = voteCount;
    }

    public PIPlayer(string name, bool isImpostor, Vector3[] rotations, int votedCount, int vote) : this(name, isImpostor, rotations, votedCount)
    {
        Vote = vote;
    }


    public string GetRoll()
    {
        return IsImpostor ? "インポスター" : "人形使い";
    }

    /// <summary>
    /// 要素数が17のVector3[]をRotationsにセットする
    /// </summary>
    /// <param name="rotations"></param>
    public void SetRotations(Vector3[] rotations)
    {
        Assert.IsTrue(rotations.Length == 17, "PlayerInfo.Rotationsに与えられたVector3[]の要素数が17ではない");

        Rotations = rotations;
    }
}
