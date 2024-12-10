using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSample : MonoBehaviour
{
    private GameObject player; //プレイヤーの情報の格納
    private Vector3 offset;　//相対距離の取得

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player 1");

        offset = transform.position - player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(player.transform.position.x);
        transform.position = player.transform.position + offset;
    }
}
