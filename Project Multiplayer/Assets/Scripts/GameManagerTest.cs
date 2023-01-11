using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
// namespace Photon.Pun.Demo.PunBasics
// {
public class GameManagerTest : MonoBehaviourPunCallbacks
{
    public GameObject quitScene, gameOverScene;
    PhotonView pv;
    static public GameManagerTest Instance;
    private bool leavingRoom;
    //[SerializeField] private GameObject[] characters;
    public Transform spawnPoints;
    [SerializeField] private GameObject[] characterPrefabs;
    private int characterindex;
    public bool LeaveRoom()
    {
        return PhotonNetwork.LeaveRoom();
    }

    public void LoadCharacter()
    {
        int characterIndex = PlayerPrefs.GetInt("CharacterIndex");

        PhotonNetwork.Instantiate(characterPrefabs[characterIndex].name, spawnPoints.position, Quaternion.identity);
        //i = PhotonNetwork.Instantiate(characterPrefabs, spawnPoints.position, Quaternion.identity);
        //   GameObject i = (GameObject)PhotonNetwork.Instantiate(characterPrefabs[characterIndex], spawnPoints.position, Quaternion.identity);
        //PhotonNetwork.Instantiate(characterPrefabs[characterIndex], spawnPoints.position, Quaternion.identity);
        // int randomNum = Random.Range(0, spawnPoints.Length);
        // Transform spawnPoint = spawnPoints[randomNum];
    }
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
    public static bool IsPaused;




    void Start()
    {

        LoadCharacter();
        Instance = this;
    }

    public void OnClick_Select(Character character)
    {
        PhotonNetwork.LoadLevel("Map2D");
        //SceneManager.LoadScene("Map2D");
        if (character != null)
        {
            return;
        }
        else
        {

        }

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))//กด ESC
        {
            Application.Quit();
            IsPaused = !IsPaused;//IsPaused เปลี่ยนจาก flase เป็น true
            pause();//เรียกฟังก์ชัน pause
        }
    }
    public void OnClick_StartGame()
    {
        SceneManager.LoadScene("Lobby");

    }
    public void GameOver()
    {
        gameOverScene.SetActive(true);
    }
    void pause()//ฟังก์ชันหยุดเกม
    {
        quitScene.SetActive(false);//จะยังไม่เรียกใช้งาน Pause(Panel) 
        if (IsPaused)
        {
            quitScene.SetActive(true);//เรียกใช้งาน Pause(Panel) 
        }

    }
    public void OnClick_Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void OnClick_Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void OnClick_LeavRoom()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("Lobby");
    }













}
// }