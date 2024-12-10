using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class EnemySpawnScript : MonoBehaviour
{
    public EnemyScript enemyScript;
    //�G
    public GameObject enemy;
    //�G�̃X�|���W���Ԃ̐���
    int enemeSoawn = 5;
    //�X�|�[����
    public int enemySpawns = 5;
    Vector3 EnemePos = Vector3.zero;
    float spawnSpeed = 100;
    //���j��
   public int defeats = 0;
   

  
    // Start is called before the first frame update
    void Start()
    {
        enemeSoawn = 5;

    }



    // Update is called once per frame
    void Update()
    {


      
       enemeSoawn--;

        transform.position += spawnSpeed * transform.forward * Time.deltaTime;



        Debug.Log(defeats);
       

        if (enemeSoawn < 0&& enemySpawns > 5  )
        {

          
            EnemePos.x = Random.Range(0, 10) + transform.position.x;
            EnemePos.y = Random.Range(0, 10) + transform.position.y;
            EnemePos.z = Random.Range(0, 10) + transform.position.z;

           

            Instantiate(enemy, new Vector3(EnemePos.x, EnemePos.y, EnemePos.z), Quaternion.identity);
            
            enemySpawns--;
            enemeSoawn = 10;


        }

        if (defeats == 5)
        {
            enemySpawns = 10;
            defeats = 0;
        }

    }

 
}
