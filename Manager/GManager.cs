using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager Instance = null;


    public static string Villager = "人形使い";
    public static string Impostor = "インポスター";

    public static int PNUM = 1;

    public  Dictionary<string, int> IdToInt;
    public  List<Player> Players;

    public string SceneNow;

    public  string Genre { get; set; }
    public  string Theme { get; set; }

    public  int Round { get; set; }

    public  int MyID;


    public class Player
    {
        public string Name { get; set; }

        public bool IsImpostor { get; set; }

        public Vector3[] Rotations { get; set; }
    }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Instance.IdToInt = new Dictionary<string, int>();
            Instance.Players = new List<Player>();
            Instance.SceneNow = "Title";
            Instance.Round = 1;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public void SetMyID(string id)
    {
        MyID = IdToInt[id];
    }

    /// <summary>
    /// photonのidを番号で管理し、プレイヤーの名前を保存する
    /// </summary>
    /// <param name="ids"></param>
    public void SetPlayers(IEnumerable<(int i, string userId, string name, bool isImpostor)> players)
    {
        Debug.Log("<color=green> SetPlayers </color>");

        foreach((int i, string userId, string name, bool isImpostor) p in players) 
        {
            Instance.IdToInt.Add(p.userId, p.i);

            Player player = new Player();            
            player.Name = p.name;
            player.IsImpostor = p.isImpostor;
            player.Rotations = null;

            Instance.Players.Add(player);
        }

        Debug.Log("<color=green> SetPlayers Complete </color>");
    }

    /// <summary>
    /// PosingSceneで決定された回転情報を各プレイヤーのIDとともに保存する
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="rotations"></param>
    public void SetRotations(string userId, Vector3[] rotations)
    {
        Debug.Log("<color=green> Set Rotations </color>");

        if (rotations.Length != 17) { Debug.Log("Length Rotation info is not 17"); }

        int id = Instance.IdToInt[userId];
        Instance.Players[id].Rotations = rotations;
    }
}
