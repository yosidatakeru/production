using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSample : MonoBehaviour
{
    public Transform player; // �v���C���[��Transform���A�T�C��
    public Vector3 offset = new Vector3(0, 1, -3); // �J�����̃I�t�Z�b�g
    public float smoothSpeed = 40; // �J�����̒ǔ����x

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

        if (player == null) return; // �v���C���[�����ݒ�Ȃ珈�����Ȃ�

        // �J�����̖ڕW�ʒu���v�Z
        Vector3 desiredPosition = player.position + offset;

        // �X���[�Y�ɖڕW�ʒu�Ɉړ�
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // �v���C���[������
        transform.LookAt(player);

    }
}
