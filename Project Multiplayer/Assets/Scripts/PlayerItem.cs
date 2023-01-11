using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
namespace Photon.Pun.Demo.PunBasics
{
    public class PlayerItem : MonoBehaviourPunCallbacks
    {
        private PhotonHandler hash = new PhotonHandler();
        private List<GameObject> models;
        private int selectionIndex = 0;
        //     ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
        //     public Image playerAvatar;
        public GameObject[] character;
        private int characterIndex;

        public void Character(int index)
        {
            for (int i = 0; i < character.Length; i++)
            {
                character[i].SetActive(false);
            }
            this.characterIndex = index;
            character[index].SetActive(true);
        }
        void Start()
        {
            models = new List<GameObject>();
            foreach (Transform t in transform)
            {
                models.Add(t.gameObject);
                t.gameObject.SetActive(false);

            }
            models[selectionIndex].SetActive(true);
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Select(4);
            }
        }
        public void Select(int index)
        {
            if (index == selectionIndex)
                return;
            if (index < 0 || index >= models.Count)
                return;
            models[selectionIndex].SetActive(false);
            selectionIndex = index;
            models[selectionIndex].SetActive(true);
        }
        public void Select()
        {
            PlayerPrefs.SetInt("CharacterIndex", characterIndex);
            PhotonNetwork.LoadLevel("Map2D");

        }
        public void SetHash()
        {
            // PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        }
        //     void UpdatePlayerItem(PlayerTestMovement player)
        //     {
        //         if (player.CustomProperties.ContainsKey("playerAvatar"))
        //         {
        //             playerAvatar.sprite = avatars[(int)player.CustomProperties["playerAvatar"]];
        //             playerProperties["playerAvatar"] = (int)player.CustomProperties["playerAvatar"];
        //         }
        //         else
        //         {
        //             playerProperties["playerAvatar"] = 0;
        //         }
        //     }
        //     void OnClick_Right()
        //     {
        //         if ((int)playerProperties["playerAvatar"] == 0)
        //         {
        //             playerProperties["playerAvatar"] = 0;
        //         }
        //         else
        //         {
        //             playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] + 1;
        //             PhotonNetwork.SetPlayerCustomProperties(playerProperties);
        //         }
        //     }
        //     void OnClick_Letf()
        //     {
        //         if ((int)playerProperties["playerAvatar"] == 0)
        //         {
        //             playerProperties["playerAvatar"] = avatars.Length - 1;
        //         }
        //         else
        //         {
        //             playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] - 1;
        //         }
        //         PhotonNetwork.SetPlayerCustomProperties(playerProperties);
        //     }
        //     public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
        //     {
        //         if (player == targetPlayer)
        //         {
        //             UpdatePlayerItem(targetPlayer);
        //         }
        //     }
        //     void Update()
        //     {

        //     }
    }
}