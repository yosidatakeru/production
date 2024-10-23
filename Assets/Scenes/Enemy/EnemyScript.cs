using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    EnemySpawnScript enemySpawn;

    //int enespon = 0;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    

    // Update is called once per frame
    void Update()
    {

         //enespon = enemySpawn.GetebenySpawns();
         //enespon ++;
         //enemySpawn.SetenemySpawns(enespon);


       

    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(enemySpawnScript.enemySpawns);
      
        if (collision.gameObject.tag == "Bullet")
        {

         
            //ìñÇΩÇ¡ÇΩÇÁè¡ñ≈
            Destroy(gameObject);

          
            
        }
       
    }
     
    

    
}
