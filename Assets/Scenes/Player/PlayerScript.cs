using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public  class PlayerScript : MonoBehaviour
{
    public GameObject Bullet;
    //�v���C���[�̈ړ��X�s�[�h
    public float playerSpeed = 10;

   

    ////�e�̃C���^�o������
    int timeUntilNextShot = 0;

    int bulletNexst = 10;

    Vector3 playerRotation = Vector3.zero;
  
    // Start is called before the first frame update
    void Start()
    {
        playerRotation = Vector3.zero;
    }

    

    // Update is called once per frame
    void Update()
    {

         transform.rotation = Quaternion.Euler(playerRotation.x,playerRotation.y,playerRotation.z);

        //�v���C���[�̈ړ�����
        // W�L�[�i�O���ړ��j
        if (Input.GetKey(KeyCode.W) && transform.position.y <= 15.0f)
        {

            transform.position += playerSpeed * Vector3.up * Time.deltaTime;
            
            //��]����
            if (playerRotation.x > -20)
            {
                playerRotation.x--;
            }
        }
        else if (playerRotation.x <= 0)
        {
            //��]����
            playerRotation.x++;
            
        }


        // S�L�[�i����ړ��j
        if (Input.GetKey(KeyCode.S) && transform.position.y >= -5.0)
        {
            transform.position -= playerSpeed * Vector3.up * Time.deltaTime;

            //��]����
            if (playerRotation.x <= 20)
            {
                playerRotation.x++;
            }

        }
        else if (playerRotation.x >= 0)
        {
            //��]����
            playerRotation.x--;

        }
        


        // D�L�[�i�E�ړ��j
        if (Input.GetKey(KeyCode.D) && transform.position.x <= 10.0f)
        {
            transform.position += playerSpeed * Vector3.right * Time.deltaTime;

            //��]����
            if (playerRotation.z >= -35)
            {
                playerRotation.z--;
            }
        }
        else if (playerRotation.z <= 0)
        {
            //��]����
            playerRotation.z++;

        }

        // A�L�[�i���ړ��j
        if (Input.GetKey(KeyCode.A) && transform.position.x >= -20.0f)
        {
            transform.position -= playerSpeed * Vector3.right * Time.deltaTime;
            //��]����
            if (playerRotation.z <= 35)
            {
                playerRotation.z++;
            }
        }
        else if (playerRotation.z >= 0)
        {
            //��]����
            playerRotation.z--;

        }







        timeUntilNextShot--;
        if (Input.GetKey(KeyCode.Space) && timeUntilNextShot <= 0)
        {
         
           
            Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);


            timeUntilNextShot = bulletNexst; 

        }
}

    

}
