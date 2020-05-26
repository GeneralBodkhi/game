using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class person1 : MonoBehaviour

{
    public float speed = 4.0F;
    public float Life = 100.0F;
    public float jumpSpeed = 8.0F;

    public float gravity = 20.0F;
     private Vector3 moveDir = Vector3.zero;
     private CharacterController controller;
     public AudioClip step;
     public AudioSource audio;
     private float timeOut=1.0f;
     private float footstepTime = 0.4F;
     private float fall = 0.0f;
     
    // Start is called before the first frame update
     private void OnCollisionEnter(Collision other)
     {
         if(other.collider.tag == "enemy_bullet")
             //if(loh)
         {
             if (Life > 0)
             {
                 Life -= 30;
             }
             else
             {
                 Debug.Log("умер");
                 SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);}
         }

         if (other.collider.tag == "enemy")
         //if(loh)
         {
             if (Life > 0)
             {
                 Life -= 10;
             }
       
         }
     }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Life < 0) { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
        if (Life < 100)
        {
            Life += Time.deltaTime;
        }
       
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

            if (fall >= 5)
            {
                Life -= fall; fall = 0;
            }
            else { fall = 0; }
        
        }
        else
        {
            fall += Time.deltaTime*15;
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            moveDir.y = jumpSpeed;
        }

        moveDir.y -= gravity * Time.deltaTime;

        controller.Move(moveDir * Time.deltaTime);
 
    }

    void OnGUI()
    {

        GUIStyle styleTime = new GUIStyle();
        styleTime.fontSize = 30;
        styleTime.fontStyle = FontStyle.Italic;
        styleTime.normal.textColor = Color.white;
        GUI.Box(new Rect(0, 0, 100, 100), " " + Math.Round(Life), styleTime);

    }
   
}
