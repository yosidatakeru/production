using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class EnemySpawnScript : MonoBehaviour
{
    
    //�G
    public GameObject enemy;
    //�n��̓G
    public GameObject groundEnemy;
    //�G�̃X�|���W���Ԃ̐���
    int enemeSoawn = 5;
    //�X�|�[����
    public int enemySpawns = 5;
    //�G�l�~�[�̍��W
    Vector3 EnemePos = Vector3.zero;
    //�G�̑���
    //float spawnSpeed = 100;
    //���j��
   public int defeats = 0;
   

  
    // Start is called before the first frame update
    void Start()
    {
      //  enemeSoawn = 5;

    }



    // Update is called once per frame
    void Update()
    {


      �@//�G���o�Ă��鎞��
        enemeSoawn--;
        //�X�{������OBJ�����ɐi�߂�
       // transform.position += spawnSpeed * transform.forward * Time.deltaTime;



       // Debug.Log(defeats);
       

        if (enemeSoawn < 0&& enemySpawns > 5  )
        {

            //�G�̃X�|�[���ʒu
            EnemePos.x = Random.Range(0, 10) + transform.position.x;
            EnemePos.y = Random.Range(0, 10) + transform.position.y;
            EnemePos.z = Random.Range(0, 10) + transform.position.z;

           
            //�I�u�W�F�N�g�̃X�|�[��
            Instantiate(enemy, new Vector3(EnemePos.x, EnemePos.y, EnemePos.z), Quaternion.identity);
          //  Instantiate(groundEnemy, new Vector3(EnemePos.x, EnemePos.y, EnemePos.z), Quaternion.identity);
          //�X�|�[�����邽�тɌ��炷
            enemySpawns--;
            //���̓G�̃X�|�[���܂ł̎���
            enemeSoawn = 10;


        }
        
        //��萔�|���ƃ��X�|�[��
        if (defeats == 5)
        {
            enemySpawns = 10;
            defeats = 0;
        }

    }

 
}
