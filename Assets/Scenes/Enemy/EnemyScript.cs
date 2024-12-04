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
    int timeUntilNextShot = 0;
    int bulletTimerReset = 0;
    int behaviorattern = 0;

    public GameObject particle;

    EnemySpawnScript enemySpawnScript = new EnemySpawnScript();

    //âº
    int A = 0;
    //public int GetSetProperty
    //{
    //    //get { return A; }
    //    //set {  = value; }
    //}
    // Start is called before the first frame update
    void Start()
    {
        timeUntilNextShot = Random.Range(300, 600);
        bulletTimerReset = timeUntilNextShot;
    }



    // Update is called once per frame
    void Update()
    {

        transform.position += enemySpeed * transform.forward * Time.deltaTime;

        // enemySpawnScript.GetSetProperty += 1; //setÅAnumÇ10Ç…èëÇ´ä∑Ç¶ÇÈ
        Debug.Log(enemySpawnScript.GetSetProperty); //getÅAnumÇéÊìæÇµÇƒConsoleÇ…ï\é¶
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


            timeUntilNextShot = bulletTimerReset;

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
            
            
           
            //ìGÇè¡Ç∑/
            Destroy(gameObject);



        }
       
    }
     
    

    
}
