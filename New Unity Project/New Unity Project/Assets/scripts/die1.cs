using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die1 : MonoBehaviour
{
    public float life = 30.0F;
    private float regen = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "bullet") { 
            if(life > 10)
            {
                life -= 10;
            }
            else{
                Destroy(gameObject); 
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (life >= 30) { regen = 0f; }
        else
        {
            regen = 1f;
            life += Time.deltaTime * regen;
        }
    }
}
