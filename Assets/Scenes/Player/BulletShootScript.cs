using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShootScript : MonoBehaviour
{
    public GameObject Bullet;
    public PlayerScript playerScript;
    ////�e��������܂ł̎���
    //int deleteBullet= 10;
    ////�e�̃X�s�[�h
    
    ////�e�̃C���^�o������
    int timeUntilNextShot = 100;
    ////�e�����łĂ�܂ł̎���
    int nextShot = 0;
    // Start is called before the first frame update
    Vector3 BulletPos = Vector3.zero;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // timeUntilNextShot--;
        // if (Input.GetKey(KeyCode.Space) && timeUntilNextShot <= 0)
        //{

        //GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
        //Rigidbody shellRb = shell.GetComponent<Rigidbody>();
        //shellRb.AddForce(transform.forward * BulletSpeed);
        ////������������j��
        //Destroy(shell, deleteBullet);
        //timeUntilNextShot = nextShot;
        // }
        timeUntilNextShot--;
        if (Input.GetKey(KeyCode.Space) && timeUntilNextShot <= 0)
        {
            //���W���v���C���[�����ɂ���
            BulletPos.x = playerScript.transform.position.x;
            BulletPos.y = playerScript.transform.position.y;
            BulletPos.z = playerScript.transform.lossyScale.z + 5  + playerScript.transform.position.z;
            //�G�̐���
            Instantiate(Bullet, new Vector3(BulletPos.x, BulletPos.y, BulletPos.z), Quaternion.identity);
           
           
           

        }



    }
}
