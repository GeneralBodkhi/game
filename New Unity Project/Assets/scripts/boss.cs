using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class boss : MonoBehaviour
{
    public float x = 0.0f;
    public Transform bullet;
    public GameObject player;
    private NavMeshAgent navmesh;
    public float hp =150.0F;
    public float rehil = 25;
    public float damage = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        navmesh = GetComponent<NavMeshAgent>();
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
        
        Vector3 position = transform.position;
        position.y += 3.8F;
        position.x += 3.8f;

        if (hp <= 50)
        {
            x += Time.deltaTime * 70;
            if (x > 1)
            {
                Transform Bullet = (Transform) Instantiate(bullet, position, Quaternion.identity);
                Bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 2000);
                x = 0;
            }

        }

        navmesh.destination = player.transform.position;
        
        
    }
}
