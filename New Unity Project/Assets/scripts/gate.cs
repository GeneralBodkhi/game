using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gate : MonoBehaviour
{
    public float hp = 5.0F;
    private void OnCollisionEnter(Collision collision)
    {
        // if(collision.collider.tag == "bullet")
        if(collision.collider.tag == "bullet")
        {
            if (hp >= 1)
            {
                hp--;
            }
            else
            {
                Destroy(gameObject);
                Application.LoadLevel(2);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
