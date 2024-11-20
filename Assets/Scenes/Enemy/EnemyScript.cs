using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
//using UnityEditor.SceneManagement;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    EnemySpawnScript enemySpawn;
    public GameObject EnemyBullet;
    float enemySpeed = 100;
    float Speed = 4.0f;
    int timeUntilNextShot = 300;

    int behaviorattern = 2;

    public GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
       
    }



    // Update is called once per frame
    void Update()
    {

        transform.position += enemySpeed * transform.forward * Time.deltaTime;


        switch (behaviorattern)
        {

           case 0:
             
             transform.position += Speed * transform.right * Time.deltaTime;
             if (transform.position.x > 10.0f)
             {
                 Speed *= -1;
             }
             if (transform.position.x < -20.0f)
             {
                 Speed *= -1;
             } 

             break;

            case 1:

                transform.position += Speed * transform.up * Time.deltaTime;
                if (transform.position.y > 15.0f)
                {
                    Speed *= -1;
                }
                if (transform.position.y < -5.0f)
                {
                    Speed *= -1;
                }

                break;

            case 2:

                transform.position += Speed * transform.up * Time.deltaTime;
                transform.position += Speed * transform.right * Time.deltaTime;
                if (transform.position.y > 15.0f|| transform.position.x > 10.0f)
                {
                    Speed *= -1;
                }
                if (transform.position.y < -5.0f|| transform.position.x < -20.0f)
                {
                    Speed *= -1;
                }
                break;
        }
            
    








        timeUntilNextShot--;
        if (timeUntilNextShot <= 0)
        {

            //ìGÇÃê∂ê¨
            Instantiate(EnemyBullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);


            timeUntilNextShot = 300;

        }

    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(enemySpawnScript.enemySpawns);
      
        if (collision.gameObject.tag == "Bullet")
        {
            GetComponent<BoxCollider>().enabled = false;
            Instantiate(particle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            //ìñÇΩÇ¡ÇΩÇÁè¡ñ≈
            GetComponent<MeshRenderer>().enabled = false;

            //Destroy(particle);

            // Destroy(gameObject);



        }
       
    }
     
    

    
}
