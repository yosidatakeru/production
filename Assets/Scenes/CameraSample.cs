using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSample : MonoBehaviour
{
    private GameObject player; //�v���C���[�̏��̊i�[
    private Vector3 offset;�@//���΋����̎擾

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
