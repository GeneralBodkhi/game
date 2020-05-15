using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float Live = 10.0F;
    public float Timer = 0.0F;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Live < Timer)
        {
            Destroy(gameObject);
        }
    }
}
