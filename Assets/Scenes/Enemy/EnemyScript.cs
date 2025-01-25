using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
//using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    //enemy�X�N���v�g�̌Ăяo��
    EnemySpawnScript enemySpawn;
    //�e�̃I�u�W�F�N�g�̌Ăяo��
    public GameObject EnemyBullet;
    //���ɉ�����X�s�[�h
    float enemySpeed = 100;
    //�G�̃X�s�[�h
    float Speed = 4.0f;
    //�G�̍U������
    int timeUntilNextShot = 0;
    //�e�̐��䗐��
    int bulletTimerReset = 0;

    //�G�̓�������
    int behaviorattern = 0;

    int comboScore = 0;

    int score = 0;

    int destroyScore = 100;

    public GameObject particle;

    EnemySpawnScript enemySpawnScript;

    ScoreScript scoreScript;

    ComboSceorwScript comboSceorwScript;

   private ComboGaugeScript comboGaugeScript;

    private GameObject EnemySpawnObject; 



 // Start is called before the first frame update
    void Start()
    {
        timeUntilNextShot = Random.Range(300, 600);
        bulletTimerReset = timeUntilNextShot;
        enemySpawnScript = GameObject.Find("EnemySpawnObject").GetComponent<EnemySpawnScript>();
        scoreScript = GameObject.Find("ScoreText (TMP)").GetComponent<ScoreScript>();
        comboSceorwScript = GameObject.Find("ComboScore (TMP)").GetComponent<ComboSceorwScript>();
        comboGaugeScript = GameObject.Find("ComboGauge").GetComponent<ComboGaugeScript>();
        behaviorattern = Random.Range(0, 1+1);
    }



    // Update is called once per frame
    void Update()
    {

        //transform.position += enemySpeed * transform.forward * Time.deltaTime;

       
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
            
    







        //�U��
        timeUntilNextShot--;
        if (timeUntilNextShot <= 0)
        {
           
            //�G�̐���
            Instantiate(EnemyBullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

           // EnemySpawn;
            timeUntilNextShot = bulletTimerReset;

        }

    }

    //�G�̓����蔻��
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(enemySpawnScript.enemySpawns);
      
        if (collision.gameObject.tag == "Bullet")
        {
            GetComponent<BoxCollider>().enabled = false;
            Instantiate(particle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            //�������������
            GetComponent<MeshRenderer>().enabled = false;
            enemySpawnScript.defeats += 1;

            comboGaugeScript.Gauge = 600;

          //�X�R�A�Y�̏���
          //������������
          score =  comboSceorwScript.conboScore * destroyScore / 2;

            //�X�R�A�̎󂯓n��
            scoreScript.score += destroyScore + score;

            comboSceorwScript.conboScore += 1;


            //�G������/
            Destroy(gameObject);



        }
       
    }
     
    

    
}
