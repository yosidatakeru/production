using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletScript : MonoBehaviour
{

    public GameObject shellPrefab;

    //�e��������܂ł̎���
    int deleteBullet = 1;
    //�e�̃X�s�[�h
    float BulletSpeed = 800;
    //�e�̃C���^�o������
    int timeUntilNextShot = 0;
    //�e�����łĂ�܂ł̎���
    int nextShot = 100; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

     
    // Update is called once per frame
    void Update()
    {

        timeUntilNextShot--;  
       if (Input.GetKey(KeyCode.Space)&& timeUntilNextShot <= 0)
       {

           GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
           Rigidbody shellRb = shell.GetComponent<Rigidbody>();
           shellRb.AddForce(transform.forward * BulletSpeed);
           //������������j��
           Destroy(shell, deleteBullet);
            timeUntilNextShot =nextShot ;
       }
        
    }
   
}
