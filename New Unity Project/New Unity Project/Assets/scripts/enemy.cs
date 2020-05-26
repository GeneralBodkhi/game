using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    private NavMeshAgent navmesh;
    public GameObject person;
    public Transform bullet;
    public float hp=200.0F;
    public float hpPlus = 20.0F;
    public float damage = 0.0F;
    private float x = 0.0F;
    
    // Start is called before the first frame update
    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "bullet")
        {
            if (hp > 10)
            {
                hp -= 10; 
                damage++;
            
            }
            else
            {
                Destroy(gameObject);
            }
            if (damage == 5) 
            { 
                hp += hpPlus;
                damage = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.y += 3.8F;
        position.x += 2.0F;
        x += Time.deltaTime * 10;
        if (x > 1)
        {
            Transform Bullet = (Transform)Instantiate(bullet, position, Quaternion.identity);
            Bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 2000);
            x = 0;
        }
        navmesh.destination = person.transform.position;
    }
}
