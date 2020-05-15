using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       // if(collision.collider.tag == "bullet")
       if(collision.collider.tag == "bullet")
            {
                Destroy(gameObject);//уничтожаем объект со скриптом
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
