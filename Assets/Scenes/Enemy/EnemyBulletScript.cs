using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    int speed = 80;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5);
        transform.position += speed * transform.forward * Time.deltaTime;
    }
}
