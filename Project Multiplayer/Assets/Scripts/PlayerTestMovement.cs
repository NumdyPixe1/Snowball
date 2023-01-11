using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
namespace Photon.Pun.Demo.PunBasics
{

    public class PlayerTestMovement : MonoBehaviourPun
    {
        public SpriteRenderer sr;
        public AudioSource audioSource;
        // public TextMeshProUGUI nameText;
        Animator animator;
        PhotonView pv;
        const float groundCheckRiadus = 0.2f;
        [SerializeField] Transform groundCheckCollider;
        [SerializeField] private bool IsGrounded;
        [SerializeField] private bool jump;
        public Vector2 moveDirector = Vector2.zero;
        [SerializeField] private float speed = 10f;
        [SerializeField] private float jumpSpeed = 15f;
        [SerializeField] private LayerMask groundLayer;

        Rigidbody2D rb2D;
        #region  MonoBehaviour CallBacks
        void Start()
        {
            sr = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            rb2D = GetComponent<Rigidbody2D>();
            pv = GetComponent<PhotonView>();

        }

        void Update()
        {
            ProcessInput();




        }
        public void Dead()
        {
            animator.SetTrigger("IsDead");
        }
        #endregion
        public void ProcessInput()
        {
            if (pv.IsMine)
            {
                float moveDirector = Input.GetAxisRaw("Horizontal");
                rb2D.velocity = new Vector2(moveDirector * speed, rb2D.velocity.y);
                if (moveDirector < -0.1f)//ไปขวา
                {

                    animator.SetBool("IsRun", true);
                    sr.flipX = true;

                }
                else if (moveDirector > 0.1f)//ไปซ้าย
                {

                    sr.flipX = false;
                    animator.SetBool("IsRun", true);

                }
                if (moveDirector == 0)
                {
                    animator.SetBool("IsRun", false);
                }

                //Jump
                if (Input.GetButtonDown("Jump") && !jump)
                {
                    audioSource.Play();
                    animator.SetBool("IsJump", true);
                    rb2D.velocity = Vector2.up * jumpSpeed;
                    jump = true;
                }
                if (rb2D.velocity.y == 0)//ระหว่างโดด = velocity มากกว่าหรือเท่ากับ 0
                {
                    animator.SetBool("IsJump", false);
                    jump = false;
                }

            }




        }
        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                ProcessInput();
            }
            else if (stream.IsReading)
            {

            }
        }




    }

}


