using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //�v���C���[�̑��x
    float speed = 6.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�̈ړ�����
        //��Ɉړ�
        if (Input.GetKey(KeyCode.W))
        {
            transform.position +=  speed * transform.up * Time.deltaTime;
        }
        //���Ɉړ�
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= speed * transform.up * Time.deltaTime;
        }
        //�E�Ɉړ�
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += speed * transform.right * Time.deltaTime;
        }
        //���Ɉړ�
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= speed * transform.right * Time.deltaTime;
        }
        
        //�e�̔���


    }
}
