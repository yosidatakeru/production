using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class BulletScript : MonoBehaviour
{
    float bulletSpeed = 20;


    // Start is called before the first frame update
    void Start()
    {
        
    }

     
    // Update is called once per frame
    void Update()
    {
        transform.position += bulletSpeed * transform.forward * Time.deltaTime;
        Destroy(gameObject,3);
    }

    
    void OnCollisionEnter(Collision Bullet)
    {
        if(Bullet.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
         

        
    }

}
