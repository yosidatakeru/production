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
    int enemeSoawn = 10;
    //�X�|�[����
    public int enemySpawns = 10;
    Vector3 EnemePos = Vector3.zero;
    float spawnSpeed = 100;
   

   public int GetebenySpawns() { return enemySpawns; }
   public void  SetenemySpawns(int enemeSpawns_) { enemySpawns = enemeSpawns_; }
    // Start is called before the first frame update
    void Start()
    {

    
        
    }

  

    // Update is called once per frame
    void Update()
    {

        
        
        enemeSoawn--;

        transform.position += spawnSpeed * transform.forward * Time.deltaTime;




        if (enemeSoawn < 0&& enemySpawns > 0 )
        {

          
            EnemePos.x = Random.Range(0, 10) + transform.position.x;
            EnemePos.y = Random.Range(0, 10) + transform.position.y;
            EnemePos.z = Random.Range(0, 10) + transform.position.z;

           

            Instantiate(enemy, new Vector3(EnemePos.x, EnemePos.y, EnemePos.z), Quaternion.identity);
            enemySpawns--;
            enemeSoawn = 10;

        }
    }

 
}
