using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public  class PlayerScript : MonoBehaviour
{
    public GameObject Bullet;
    //�v���C���[�̈ړ��X�s�[�h
    public float playerSpeed = 100;

    float speed = 100;

    ////�e�̃C���^�o������
    int timeUntilNextShot = 0;

    int bulletNexst = 10;

    Vector3 playerRotation = Vector3.zero;
  
    // Start is called before the first frame update
    void Start()
    {
       
    }

    

    // Update is called once per frame
    void Update()
    {

        this.transform.rotation = Quaternion.Euler(playerRotation.x,playerRotation.y,playerRotation.z);

        //�v���C���[�̈ړ�����
        // W�L�[�i�O���ړ��j
        if (Input.GetKey(KeyCode.W) && transform.position.y <=15.0f  )
        {

            transform.position += playerSpeed * transform.up * Time.deltaTime;
           
        }

        // S�L�[�i����ړ��j
        if (Input.GetKey(KeyCode.S) && transform.position.y >= -5.0)
        {
            transform.position -= playerSpeed * transform.up * Time.deltaTime;
        }

        // D�L�[�i�E�ړ��j
        if (Input.GetKey(KeyCode.D) && transform.position.x <= 10.0f)
        {
            transform.position += playerSpeed * transform.right * Time.deltaTime;
           
        }

        // A�L�[�i���ړ��j
        if (Input.GetKey(KeyCode.A) && transform.position.x >= -20.0f)
        {
            transform.position -= playerSpeed * transform.right * Time.deltaTime;
        }

        //if (Input.GetKey(KeyCode.Q) && transform.position.x >= -20.0f)
        //{

            transform.position += speed * transform.forward * Time.deltaTime;
       // }

       

         timeUntilNextShot--;
        if (Input.GetKey(KeyCode.Space) && timeUntilNextShot <= 0)
        {
         
           
            Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);


            timeUntilNextShot = bulletNexst; 

        }
}

    

}
