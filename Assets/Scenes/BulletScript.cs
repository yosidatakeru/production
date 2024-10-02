using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletScript : MonoBehaviour
{

    public GameObject shellPrefab;

    //弾が消えるまでの時間
    int deleteBullet = 1;
    //弾のスピード
    float BulletSpeed = 800;
    //弾のインタバル制御
    int timeUntilNextShot = 0;
    //弾が次打てるまでの時間
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
           //生成した球を破壊
           Destroy(shell, deleteBullet);
            timeUntilNextShot =nextShot ;
       }
        
    }
   
}
