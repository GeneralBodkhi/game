using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class person : MonoBehaviour

{
    public float speed = 4.0F;

    public float jumpSpeed = 8.0F;

    public float gravity = 20.0F;
     private Vector3 moveDir = Vector3.zero;
     private CharacterController controller;
     public AudioClip step;
     public AudioSource audio;
     private float timeOut=1.0f;
     private float footstepTime = 0.4F;
     
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        timeOut += Time.deltaTime*2;
        
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if(controller.isGrounded)
        {
            if (Input.GetButton("Horizontal")&timeOut>footstepTime || Input.GetButton("Vertical")&timeOut>footstepTime){
                timeOut = 0;
                audio.PlayOneShot(step);
            }

            
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= speed;
            
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            moveDir.y = jumpSpeed;
        }

        moveDir.y -= gravity * Time.deltaTime;

        controller.Move(moveDir * Time.deltaTime);
    }

    private void Awake()
    {
        
    }
}
