using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot1 : MonoBehaviour
{
    public Transform Bullet;
    public Transform light_point;

    private AudioSource AudioS;
   // public Transform camera;
    public float bulletSpeed = 50.0F;
    // Start is called before the first frame update
    void Start()
    {
        AudioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Transform bullet = (Transform) Instantiate(Bullet, light_point.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
            AudioS.Play();
        }
    }
}
