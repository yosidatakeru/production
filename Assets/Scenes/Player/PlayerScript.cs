using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public  class PlayerScript : MonoBehaviour
{

    //プレイヤーの移動スピード
    public float playerSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの移動処理
        // Wキー（前方移動）
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += playerSpeed * transform.up * Time.deltaTime;
        }

        // Sキー（後方移動）
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= playerSpeed * transform.up * Time.deltaTime;
        }

        // Dキー（右移動）
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += playerSpeed * transform.right * Time.deltaTime;
        }

        // Aキー（左移動）
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= playerSpeed * transform.right * Time.deltaTime;
        }


    }

    

}
