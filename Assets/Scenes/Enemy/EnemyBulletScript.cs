using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    //�e�̃X�s�[�h
    int speed = 15;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�e��5�b������
        Destroy(gameObject, 5);
        //�e��O�ɔ�΂�
        transform.position += speed * transform.forward * Time.deltaTime;
    }
}
