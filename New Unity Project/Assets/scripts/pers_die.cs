﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using  System;

public class pers_die : MonoBehaviour
{
    public float Life = 100.0F;
   // public Transform loh;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "enemy")
        {
            if (Life > 0)
            {
                Life -= 10;
            }
            else
            {
                Debug.Log("умер");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);}
        }
       
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Life < 100)
        {
            Life += Time.deltaTime;
        }
    }
    
    void OnGUI()
    {

        GUIStyle styleTime = new GUIStyle();
        styleTime.fontSize = 30;
        styleTime.fontStyle = FontStyle.Italic;
        styleTime.normal.textColor = Color.white;
        GUI.Box(new Rect(0,0,100,100), " "+Math.Round(Life), styleTime);
            
    }
}
