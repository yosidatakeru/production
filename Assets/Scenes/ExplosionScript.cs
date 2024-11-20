using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

[RequireComponent(typeof(Rigidbody))] //Rigidbody���A�^�b�`���Ĕ��e�����R����������
public class ExplosionScript : MonoBehaviour
{
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Renderer>().material.color = Color.black;
        particle.startColor = new Color32(255, 25, 0, 255); //�p�[�e�B�N���̐F��ύX
        particle.startSize = 5.0f; //�p�[�e�B�N���̃T�C�Y��ύX
        particle.startLifetime = 1.0f; //�p�[�e�B�N���̐������Ԃ�ύX
        particle.emission.SetBursts(
            new ParticleSystem.Burst[]
            {
                new ParticleSystem.Burst(0, 300) //�p�[�e�B�N���̔�������300�ɐݒ�
            });

        var main = particle.main;
        main.loop = false; //�p�[�e�B�N���̔��������[�v�����Ȃ�
        main.duration = 1.0f; //�p�[�e�B�N���𔭐������鎞�Ԃ�ύX

        //�p�[�e�B�N��������ɕ��o����
        var shape = particle.shape;
        shape.shapeType = ParticleSystemShapeType.Sphere;

        //�p�[�e�B�N���̓����蔻���L���ɂ���
        var collision = particle.collision;
        collision.enabled = true;
        collision.type = ParticleSystemCollisionType.World;
        collision.sendCollisionMessages = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        
            Explode(); //���e���n�ʂɓ��������甚��������
        
    }

    void Explode()
    {
        GetComponent<Renderer>().material.color = new Color32(255, 25, 0, 255);
        Instantiate(particle, this.transform.position, Quaternion.identity); //�p�[�e�B�N���𔭐�������
        Destroy(this.gameObject, 0.5f); //0.5�b��ɔ��e�̃I�u�W�F�N�g�����ł�����
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
