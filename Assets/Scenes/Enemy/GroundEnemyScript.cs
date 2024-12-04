using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyScript : MonoBehaviour
{
    public GameObject EnemyBullet;
    EnemySpawnScript enemySpawn;
    public GameObject particle;
   public GameObject player;
    float enemySpeed = 100;
    float Speed = 4.0f;
    int timeUntilNextShot = 0;
    int bulletTimerReset = 0;
    int behaviorattern = 0;

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


        transform.LookAt(player.transform);




      



        timeUntilNextShot--;
        if (timeUntilNextShot <= 0)
        {

            //�e�̐���
            Instantiate(EnemyBullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);


            timeUntilNextShot = bulletTimerReset;

        }


        void OnCollisionEnter(Collision collision)
        {
            //Debug.Log(enemySpawnScript.enemySpawns);

            if (collision.gameObject.tag == "Bullet")
            {
                GetComponent<BoxCollider>().enabled = false;
                Instantiate(particle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                //�������������
                GetComponent<MeshRenderer>().enabled = false;



                //�G������/
                Destroy(gameObject);



            }
        }
    }
}

