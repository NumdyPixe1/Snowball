using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
namespace Photon.Pun.Demo.PunBasics
{
    public class PlayerManagerTest : MonoBehaviourPunCallbacks
    {
        public TextMeshProUGUI nameText;

        public AudioSource audioSource;
        public bool dead = false;
        private bool leavingRoom;
        PlayerTestMovement playerTestMovement;
        public GameManagerTest gameManagerTest;
        PhotonView pv;
        public int Health = 100;
        public Text HealthText;
        void Awake()
        {

        }
        void Start()
        {

            pv = GetComponent<PhotonView>();
            if (photonView.IsMine)
            {
                nameText.text = PhotonNetwork.NickName;
                if (playerTestMovement == null)
                {
                    GameObject _c = GameObject.FindGameObjectWithTag("Player") as GameObject;
                    playerTestMovement = _c.GetComponent<PlayerTestMovement>();
                }
            }
            else
            {
                nameText.text = pv.Owner.NickName;
            }
        }

        void Update()
        {
            if (pv.IsMine)
            {
                HealthText.text = Health.ToString();
                if (this.Health <= 0 && !this.leavingRoom)
                {
                    dead = true;
                    playerTestMovement.Dead();
                    gameManagerTest.GameOver();
                    this.leavingRoom = GameManagerTest.Instance.LeaveRoom();
                    playerTestMovement.enabled = false;
                    // StartCoroutine(COStunPause(3f));

                }
            }
        }
        // public IEnumerator COStunPause(float pasuetime)
        // {
        //     yield return new WaitForSeconds(pasuetime);
        //     this.leavingRoom = GameManagerTest.Instance.LeaveRoom();
        // }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "SnowBall")
            {
                audioSource.Play();
                Health = Health - 10;
            }
        }
        // public void TakeDamge(int damage)
        // {

        // }




    }
}