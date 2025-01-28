using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 20f; // �e�̑��x
    public float rotationSpeed = 5f; // ��]���x
    public GameObject explosionEffect; // �����G�t�F�N�g

    private Transform target; // �^�[�Q�b�g

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            // �^�[�Q�b�g�����Ȃ��ꍇ�A�e���폜
            Destroy(gameObject);
            return;
        }

        // �^�[�Q�b�g�Ɍ�����
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // �O�i
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // �^�[�Q�b�g�ɓ��B�����ꍇ
        if (Vector3.Distance(transform.position, target.position) < 1f)
        {
            Explode();
        }
        void Explode()
        {
            // �����G�t�F�N�g�𐶐�
            if (explosionEffect != null)
            {
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
            }

            // ���g���폜
            Destroy(gameObject);
        }
    }
}
