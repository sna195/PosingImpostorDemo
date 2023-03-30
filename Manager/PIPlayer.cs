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
        Assert.IsTrue(rotations.Length == new RotateParts().RotateCount, "PlayerInfo.Rotations�ɗ^����ꂽVector3[]�̒�����RotateParts().RotateCount�ƈ�v���Ȃ�");

        Rotations = rotations;
        VotedCount = voteCount;
    }

    public PIPlayer(string name, bool isImpostor, Vector3[] rotations, int votedCount, int vote) : this(name, isImpostor, rotations, votedCount)
    {
        Vote = vote;
    }


    public string GetRoll()
    {
        return IsImpostor ? "�C���|�X�^�[" : "�l�`�g��";
    }

    /// <summary>
    /// �v�f����17��Vector3[]��Rotations�ɃZ�b�g����
    /// </summary>
    /// <param name="rotations"></param>
    public void SetRotations(Vector3[] rotations)
    {
        Assert.IsTrue(rotations.Length == 17, "PlayerInfo.Rotations�ɗ^����ꂽVector3[]�̗v�f����17�ł͂Ȃ�");

        Rotations = rotations;
    }
}
