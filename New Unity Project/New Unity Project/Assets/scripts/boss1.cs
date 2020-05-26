using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class boss1 : MonoBehaviour
{
    private NavMeshAgent navmesh;
    public Transform bullet;
    public Transform podsos;
    public GameObject player;
    public float hp = 150.0f;
    public float rehil = 25.0f;
    private float damage = 0.0f;
    private float shoot = 0.0f;
    private float posos = 0.0f;
    public Transform light_point;



    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "bullet")
        {
            if (hp >= 10) { hp -= 10; damage++; }

            else
            {
                Destroy(gameObject);
            }
        }
        if (damage == 5.0)
        {
            damage = 0;
            hp += rehil;
        }
    }
    private void boss_shoot()
    {
        Vector3 position = transform.position;
        //position.y -= 0.1f;
        //position.x += 1.0f;

        shoot += Time.deltaTime * 5;
        if (shoot > 1)
        {
            Transform Bullet = (Transform)Instantiate(bullet, light_point.transform.position, Quaternion.identity);
            Bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 5000);
            shoot = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (hp <= 50)
        {
            boss_shoot();
        }

        if (hp <= 20)
        {
            Vector3 position = transform.position;
            posos += Time.deltaTime * 5;
            if (posos >= 1)
            {
                
                Transform Podsos = (Transform) Instantiate(podsos, position, Quaternion.identity);
                Podsos.GetComponent<Rigidbody>().AddForce(transform.forward);
                posos = 0;
            }
        }
        navmesh.destination = player.transform.position; 
    }
}
