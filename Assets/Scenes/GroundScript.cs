using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    // Start is called before the first frame update
    int speed = 200;
    public float resetPositionZ = 1450f; // z ���W���Z�b�g�l��ݒ�





    Vector3 groundPos = Vector3.zero;
    void Start()
    {
        groundPos.z = resetPositionZ; // �����ʒu��ݒ�
    }

    // Update is called once per frame
    void Update()
    {

        transform.position -= speed * transform.forward * Time.deltaTime;

        // z ���W�� -100 �ɋ߂��ꍇ�Ƀ��Z�b�g
        if (transform.position.z <=-550) // �덷�����e������r
        {
            Vector3 newPosition = transform.position;
            newPosition.z = groundPos.z;
            transform.position = newPosition;
        }
    }
}
