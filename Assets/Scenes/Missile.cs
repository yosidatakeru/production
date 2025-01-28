using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 20f; // 弾の速度
    public float rotationSpeed = 5f; // 回転速度
    public GameObject explosionEffect; // 爆発エフェクト

    private Transform target; // ターゲット

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
            // ターゲットがいない場合、弾を削除
            Destroy(gameObject);
            return;
        }

        // ターゲットに向かう
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // 前進
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // ターゲットに到達した場合
        if (Vector3.Distance(transform.position, target.position) < 1f)
        {
            Explode();
        }
        void Explode()
        {
            // 爆発エフェクトを生成
            if (explosionEffect != null)
            {
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
            }

            // 自身を削除
            Destroy(gameObject);
        }
    }
}
