using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShootScript : MonoBehaviour
{
    public GameObject Bullet;
    public PlayerScript playerScript;
    ////弾が消えるまでの時間
    //int deleteBullet= 10;
    ////弾のスピード
    
    ////弾のインタバル制御
    int timeUntilNextShot = 100;
    ////弾が次打てるまでの時間
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
        ////生成した球を破壊
        //Destroy(shell, deleteBullet);
        //timeUntilNextShot = nextShot;
        // }
        timeUntilNextShot--;
        if (Input.GetKey(KeyCode.Space) && timeUntilNextShot <= 0)
        {
            //座標をプレイヤー同じにする
            BulletPos.x = playerScript.transform.position.x;
            BulletPos.y = playerScript.transform.position.y;
            BulletPos.z = playerScript.transform.lossyScale.z + 5  + playerScript.transform.position.z;
            //敵の生成
            Instantiate(Bullet, new Vector3(BulletPos.x, BulletPos.y, BulletPos.z), Quaternion.identity);
           
           
           

        }



    }
}
