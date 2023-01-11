using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;

public class CreateAndJoin : MonoBehaviourPunCallbacks
{
    public TMP_InputField nameInput;
    public TMP_InputField createInput;
    public TMP_InputField joinInput;

    public void OnSetName()
    {


    }
    public void OnClick_CreateRoom()
    {
        if (string.IsNullOrEmpty(nameInput.text))//ถ้ายังไม่ได้ใส่ชื่อห้อง
        {
            print("Pls Enter your name");
            return;//ยังอยู่หน้าเดิม
        }
        else
        {
            PhotonNetwork.NickName = nameInput.text;
        }

        Debug.Log("Conenecting");//กำลังเชื่อมต่อ
        if (string.IsNullOrEmpty(createInput.text))//ถ้ายังไม่ได้ใส่ชื่อห้อง
        {
            print("Pls Createroom's name");
            return;//ยังอยู่หน้าเดิม
        }
        if (PhotonNetwork.CreateRoom(createInput.text, new RoomOptions { MaxPlayers = 2 }, null))
        {
            Debug.Log("You can Create room" + createInput.text);

        }

    }
    public void OnClick_JoinRoom()
    {
        if (string.IsNullOrEmpty(joinInput.text))//ถ้ายังไม่ได้ใส่ชื่อห้อง
        {
            return;//ยังอยู่หน้าเดิม
        }
        PhotonNetwork.JoinRoom(joinInput.text, null);
        Debug.Log("You can Join room");

        //PhotonNetwork.LocalPlayer.NickName = playerName;
    }
    public override void OnJoinedRoom()//เข้ามาในห้อง
    {
        //SceneManager.LoadScene("CharacterSelect");
        PhotonNetwork.LoadLevel("CharacterSelect");
        Debug.Log("Room Join Sucess");
        //base.OnJoinedRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        //base.OnJoinRandomFailed(returnCode, message);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        // base.OnCreateRoomFailed(returnCode, message);
    }

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Update()
    {

    }
}
