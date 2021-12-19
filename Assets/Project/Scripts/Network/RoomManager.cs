using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{
    private bool AutoMatchmaking = false;
    private string currentRoomname;

    [Header("OUTSIDE Room UI ---------------")]
    public GameObject RoomPanel;
    public InputField RoomInputField;

    [Header("IN Room UI ----------------------")]
    public Text RoomName;

    public void CreateRoom()
    {
        if (!string.IsNullOrEmpty(RoomInputField.text))
            currentRoomname = RoomInputField.text;
        else
            currentRoomname = Random.Range(100000, 999999).ToString();

        Photon.Realtime.RoomOptions roomOptions = new Photon.Realtime.RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.PlayerTtl = 3000;
        roomOptions.EmptyRoomTtl = 1000;
        PhotonNetwork.CreateRoom(currentRoomname);
    }

    public void JoinRoomByCode()
    {
        PhotonNetwork.JoinRoom(RoomInputField.text);
    }

    public void RandomJoinRoom()
    {
        AutoMatchmaking = true;
        PhotonNetwork.JoinRandomRoom();
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    #region PUN CALLBACKS

    public override void OnJoinedRoom()
    {
        Debug.Log("Room Joined => Displaying room panel");
        RoomPanel.SetActive(true);
        RoomName.text = PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateRoom();
    }

    public override void OnLeftRoom()
    {
        RoomPanel.SetActive(false);
    }

    #endregion
}
