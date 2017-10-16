using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.MyCompany.MyGame
{
    public class PlayerAnimatorManager : Photon.MonoBehaviour
    {

        public float DirectionDampTime = 0.25f;

        private Animator animator;

        // Use this for initialization
        void Start()
        {
            animator = GetComponent<Animator>();
            if(!animator)
            {
                Debug.Log("PlayerAnimatorManager is Missing Animator Component", this);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if(photonView.isMine == false && PhotonNetwork.connected == true)
            {
                return;
            }

            if (!animator)
            {
                return;
            }

            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            if (stateInfo.IsName("Base Layer.Run"))
            {
                if (Input.GetButtonDown("Jump"))
                {
                    animator.SetTrigger("Jump");
                }
            }

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            if (v < 0)
            {
                v = 0;
            }

            animator.SetFloat("Speed", h * h + v * v);
            animator.SetFloat("Direction", h, DirectionDampTime, Time.deltaTime);
        }
    }
}