using UnityEngine;
using Photon.Pun;

public class LobbyNetwork : MonoBehaviourPunCallbacks
{
    public bool UseRandom;
    public GameObject LoadingPanel;
    [SerializeField] private string playerNickname;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        LoadingPanel.SetActive(true);
    }

    void Start()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = "V0.1";


            if (UseRandom || string.IsNullOrEmpty(PlayerPrefs.GetString("Nickname")))
                playerNickname = "Player" + Random.Range(1, 99999).ToString();
            else
                playerNickname = PlayerPrefs.GetString("Nickname");
        }
    }

    #region PUN CALLBACKS

    public override void OnConnectedToMaster()
	{
        Debug.Log("Connected To Master " + PhotonNetwork.CloudRegion);
        LoadingPanel.SetActive(false);
    }

    #endregion
}
