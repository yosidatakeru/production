using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public  class PlayerScript : MonoBehaviour
{

    //�v���C���[�̈ړ��X�s�[�h
    public float playerSpeed;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    

    // Update is called once per frame
    void Update()
    {
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


    }

    

}
