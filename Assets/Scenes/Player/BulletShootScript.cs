using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShootScript : MonoBehaviour
{
    public GameObject shellPrefab;

    //弾が消えるまでの時間
    int deleteBullet= 10;
    //弾のスピード
    float BulletSpeed = 2000;
    //弾のインタバル制御
    int timeUntilNextShot = 100;
    //弾が次打てるまでの時間
    int nextShot = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilNextShot--;
        if (Input.GetKey(KeyCode.Space) && timeUntilNextShot <= 0)
        {

            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();
            shellRb.AddForce(transform.forward * BulletSpeed);
            //生成した球を破壊
            Destroy(shell, deleteBullet);
            timeUntilNextShot = nextShot;
        }
    }
}
