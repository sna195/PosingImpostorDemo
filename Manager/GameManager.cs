using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviourPunCallbacks
{
    private PhotonView _photonView;

    /// <summary>
    /// サーバの情報を持つアセット
    /// </summary>
    [SerializeField] private PhotonInfo _photonInfo;

    /// <summary>
    /// プレイヤーの情報を持つアセット
    /// </summary>
    [SerializeField] private PlayerInfo _playerInfo;

    /// <summary>
    /// シーン遷移の情報を持つアセット
    /// </summary>
    [SerializeField] private SceneInfo _sceneInfo;

    /// <summary>
    /// ジャンル・テーマの情報を持つアセット
    /// </summary>
    [SerializeField] private GenreTheme _genreTheme;

    /// <summary>
    /// インポスターの予想テーマの情報を持つアセット
    /// </summary>
    [SerializeField] private ImpostorGuess _impostorGuess;

    /// <summary>
    /// メインシーン遷移を開始するイベント
    /// </summary>
    [SerializeField] private GameEvent _startChangeSceneEvent;

    /// <summary>
    /// 役職の開示イベント
    /// </summary>
    [SerializeField] private GameEvent _startShowRollEvent;

    /// <summary>
    /// Guessシーンを開始するイベント
    /// </summary>
    [SerializeField] private GameEvent _startGuessEvent;

    /// <summary>
    /// 答えのテーマを表示するイベント
    /// </summary>
    [SerializeField] private GameEvent _showAnswerEvent;

    /// <summary>
    /// Posing完了したプレイヤーの数と全員完了した際のイベント
    /// </summary>
    private Ready _bodyCount;

    /// <summary>
    /// Posing完了したプレイヤーの数と全員完了した際のイベント
    /// </summary>
    private Ready _voteCount;



    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();

        _bodyCount = new Ready(_photonInfo.PlayerNum, _startChangeSceneEvent);
        _voteCount = new Ready(_photonInfo.PlayerNum, _startShowRollEvent);
    }

    private void Start()
    {
        if (_photonInfo.IsOffline) { PhotonNetwork.OfflineMode = true; }
        else { PhotonNetwork.ConnectUsingSettings(); }
    }

    /// <summary>
    /// ゲームに参加する
    /// </summary>
    public void StartGame()
    {
        if (!PhotonNetwork.IsConnected) { return; }

        Debug.Log("<color=yellow> StartGame </color>");

        Debug.Log("<color=red> info name </color>" + _playerInfo.MyName);

        PhotonNetwork.NickName = _playerInfo.MyName;

        // ランダムなルームに参加する
        PhotonNetwork.JoinRandomRoom();
    }

    
    public override void OnConnectedToMaster()
    {
        Debug.Log("<color=yellow> OnConnectedToMaster </color>");
    }

    /// <summary>
    /// ランダムで参加できるルームが存在しないなら、新規でルームを作成する。
    /// </summary>
    /// <param name="returnCode"></param>
    /// <param name="message"></param>
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("<color=yellow> OnJoinRandomFailed </color>");

        // ルームの参加人数を4人に設定する
        // Offline モードの場合1人
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = _photonInfo.IsOffline ? (byte)1 : (byte)_photonInfo.PlayerNum;

        PhotonNetwork.CreateRoom(null, roomOptions);
    }

    /// <summary>
    /// Roomに参加した際の処理
    /// </summary>
    public override void OnJoinedRoom()
    {
        if (_photonInfo.IsOffline)
        {
            return;
        }

        Debug.Log("<color=yellow> OnJoinedRoom </color>");

        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers) 
        {
            StartRoom();
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            StartRoom();
        }
    }

    public void StartRoom()
    {
        Debug.Log("<color=red> offline </color>" + _photonInfo.IsOffline);
        Debug.Log("<color=red> name </color>" + _playerInfo.MyName);

        // ルームが満員になったら
        Debug.Log("<color=yellow> MaxPlayers </color>");

        // 以降そのルームへの参加を不許可にする
        PhotonNetwork.CurrentRoom.IsOpen = false;

        // localプレイヤーのUserIDを記憶する
        _playerInfo.MyActorNumber = PhotonNetwork.LocalPlayer.ActorNumber;

        Player[] players = PhotonNetwork.PlayerList;

        // 現在RoomにいるプレイヤーのUserID、NickNameを記憶する
        foreach (Player player in players)
        {
            _playerInfo.Add(player);
        }

        // マスターによるインポスター、ジャンル、テーマの決定
        if (PhotonNetwork.IsMasterClient)
        {
            int impostorId = Random.Range(0, players.Length);
            _photonView.RPC(nameof(SetImpostor), RpcTarget.All, impostorId);
            _photonView.RPC(nameof(SetGenreTheme),
                RpcTarget.All,
                Random.Range(0, _genreTheme.GenreCount),
                Random.Range(0, _genreTheme.ThemeCount));
        }

        // シーンのロード
        _startChangeSceneEvent.Raise();
    }


    /// <summary>
    /// 誰かが部屋を抜けたらタイトルへ戻る
    /// </summary>
    public override void OnPhotonPlayerDisconnected()
    {
        PhotonNetwork.Disconnect();

        SceneManager.LoadScene("LeftRoom", LoadSceneMode.Additive);
    }

    public void OnBackTitle()
    {
        PhotonNetwork.Disconnect();

        _playerInfo.Initialize();
        _genreTheme.Initialize();
        _sceneInfo.Initialize();

        SceneManager.LoadScene("Manager");
    }

    /// <summary>
    /// インポスターを同期する
    /// </summary>
    /// <param name="impostor"></param>
    [PunRPC]
    private void SetImpostor(int impostor)
    {
        Debug.Log("<color=yellow> SetImpostor </color>");

        _playerInfo.GetPlayerFromId(impostor).IsImpostor = true;
    }

    /// <summary>
    /// ジャンル・テーマを同期する
    /// </summary>
    /// <param name="genre"></param>
    /// <param name="theme"></param>
    [PunRPC]
    private void SetGenreTheme(int genre, int theme)
    {
        Debug.Log("<color=yellow> SetGenreTheme </color>");

        _genreTheme.SetGenreFromIndex(genre);
        _genreTheme.SetThemeFromIndex(theme);
    }

    /// <summary>
    /// 他の参加者に自分のポーズを送る
    /// </summary>
    public void SendMyRotation()
    {
        Debug.Log("<color=green> send my rotation </color>");

        _photonView.RPC(nameof(SetRotation), RpcTarget.Others, _playerInfo.GetMyRotation());

        _bodyCount.CountUp();
    }

    [PunRPC]
    private void SetRotation(Vector3[] rotations, PhotonMessageInfo info)
    {
        _playerInfo.SetRotation(info.Sender.ActorNumber, rotations);

        _bodyCount.CountUp();
    }

    /// <summary>
    /// 自分の投票先を送信
    /// </summary>
    /// <param name="i"></param>
    public void SendVote()
    {
        _photonView.RPC(nameof(VoteCountUp), RpcTarget.All, _playerInfo.GetMyVote());
    }

    public void ResetVote()
    {
        _voteCount = new Ready(_photonInfo.PlayerNum, _startShowRollEvent);
    }

    [PunRPC]
    public void VoteCountUp(int i)
    {
        Debug.Log("<color=green> SendVote </color>");

        _playerInfo.VotedCountUp(i);

        _voteCount.CountUp();
    }

    /// <summary>
    /// インポスターは他のプレイヤーに推測したテーマのインデックスを送信する
    /// </summary>
    public void SendGuessedTheme()
    {
        Debug.Log("<color=green> SendGuessedTheme </color>");

        _photonView.RPC(nameof(GuessedTheme), RpcTarget.Others, _impostorGuess.GuessIndex);
    }

    [PunRPC]
    private void GuessedTheme(int i)
    {
        _impostorGuess.GuessIndex = i;

        _showAnswerEvent.Raise();
    }
}
