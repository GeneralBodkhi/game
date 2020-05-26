using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public float hp =150.0F;
    public float rehil = 25;
    public float damage = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        // if(collision.collider.tag == "bullet")
        if (collision.collider.tag == "bullet")
        {
            if (hp > 10) { 
                hp -= 10;
            damage++;
            }
            else
            {
                Destroy(gameObject);
            }//уничтожаем объект со скриптом
            if (damage == 5) { 
                damage = 0;
            hp += rehil;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
