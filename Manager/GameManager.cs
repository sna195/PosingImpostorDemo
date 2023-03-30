using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviourPunCallbacks
{
    private PhotonView _photonView;

    /// <summary>
    /// �T�[�o�̏������A�Z�b�g
    /// </summary>
    [SerializeField] private PhotonInfo _photonInfo;

    /// <summary>
    /// �v���C���[�̏������A�Z�b�g
    /// </summary>
    [SerializeField] private PlayerInfo _playerInfo;

    /// <summary>
    /// �V�[���J�ڂ̏������A�Z�b�g
    /// </summary>
    [SerializeField] private SceneInfo _sceneInfo;

    /// <summary>
    /// �W�������E�e�[�}�̏������A�Z�b�g
    /// </summary>
    [SerializeField] private GenreTheme _genreTheme;

    /// <summary>
    /// �C���|�X�^�[�̗\�z�e�[�}�̏������A�Z�b�g
    /// </summary>
    [SerializeField] private ImpostorGuess _impostorGuess;

    /// <summary>
    /// ���C���V�[���J�ڂ��J�n����C�x���g
    /// </summary>
    [SerializeField] private GameEvent _startChangeSceneEvent;

    /// <summary>
    /// ��E�̊J���C�x���g
    /// </summary>
    [SerializeField] private GameEvent _startShowRollEvent;

    /// <summary>
    /// Guess�V�[�����J�n����C�x���g
    /// </summary>
    [SerializeField] private GameEvent _startGuessEvent;

    /// <summary>
    /// �����̃e�[�}��\������C�x���g
    /// </summary>
    [SerializeField] private GameEvent _showAnswerEvent;

    /// <summary>
    /// Posing���������v���C���[�̐��ƑS�����������ۂ̃C�x���g
    /// </summary>
    private Ready _bodyCount;

    /// <summary>
    /// Posing���������v���C���[�̐��ƑS�����������ۂ̃C�x���g
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
    /// �Q�[���ɎQ������
    /// </summary>
    public void StartGame()
    {
        if (!PhotonNetwork.IsConnected) { return; }

        Debug.Log("<color=yellow> StartGame </color>");

        Debug.Log("<color=red> info name </color>" + _playerInfo.MyName);

        PhotonNetwork.NickName = _playerInfo.MyName;

        // �����_���ȃ��[���ɎQ������
        PhotonNetwork.JoinRandomRoom();
    }

    
    public override void OnConnectedToMaster()
    {
        Debug.Log("<color=yellow> OnConnectedToMaster </color>");
    }

    /// <summary>
    /// �����_���ŎQ���ł��郋�[�������݂��Ȃ��Ȃ�A�V�K�Ń��[�����쐬����B
    /// </summary>
    /// <param name="returnCode"></param>
    /// <param name="message"></param>
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("<color=yellow> OnJoinRandomFailed </color>");

        // ���[���̎Q���l����4�l�ɐݒ肷��
        // Offline ���[�h�̏ꍇ1�l
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = _photonInfo.IsOffline ? (byte)1 : (byte)_photonInfo.PlayerNum;

        PhotonNetwork.CreateRoom(null, roomOptions);
    }

    /// <summary>
    /// Room�ɎQ�������ۂ̏���
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

        // ���[���������ɂȂ�����
        Debug.Log("<color=yellow> MaxPlayers </color>");

        // �ȍ~���̃��[���ւ̎Q����s���ɂ���
        PhotonNetwork.CurrentRoom.IsOpen = false;

        // local�v���C���[��UserID���L������
        _playerInfo.MyActorNumber = PhotonNetwork.LocalPlayer.ActorNumber;

        Player[] players = PhotonNetwork.PlayerList;

        // ����Room�ɂ���v���C���[��UserID�ANickName���L������
        foreach (Player player in players)
        {
            _playerInfo.Add(player);
        }

        // �}�X�^�[�ɂ��C���|�X�^�[�A�W�������A�e�[�}�̌���
        if (PhotonNetwork.IsMasterClient)
        {
            int impostorId = Random.Range(0, players.Length);
            _photonView.RPC(nameof(SetImpostor), RpcTarget.All, impostorId);
            _photonView.RPC(nameof(SetGenreTheme),
                RpcTarget.All,
                Random.Range(0, _genreTheme.GenreCount),
                Random.Range(0, _genreTheme.ThemeCount));
        }

        // �V�[���̃��[�h
        _startChangeSceneEvent.Raise();
    }


    /// <summary>
    /// �N���������𔲂�����^�C�g���֖߂�
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
    /// �C���|�X�^�[�𓯊�����
    /// </summary>
    /// <param name="impostor"></param>
    [PunRPC]
    private void SetImpostor(int impostor)
    {
        Debug.Log("<color=yellow> SetImpostor </color>");

        _playerInfo.GetPlayerFromId(impostor).IsImpostor = true;
    }

    /// <summary>
    /// �W�������E�e�[�}�𓯊�����
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
    /// ���̎Q���҂Ɏ����̃|�[�Y�𑗂�
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
    /// �����̓��[��𑗐M
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
    /// �C���|�X�^�[�͑��̃v���C���[�ɐ��������e�[�}�̃C���f�b�N�X�𑗐M����
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
