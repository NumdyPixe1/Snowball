using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{

    public GameObject[] playerPrefabs;
    public Transform[] spawnPoints;
    private float minX;
    private float maxX;
    void Start()
    {
        int randomNum = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomNum];
        GameObject playerToSpawn = playerPrefabs[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
        // Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), 0);
        PhotonNetwork.Instantiate(playerToSpawn.name, spawnPoint.position, Quaternion.identity);
        // PhotonNetwork.Instantiate(playerPrefabs.name, randomPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
