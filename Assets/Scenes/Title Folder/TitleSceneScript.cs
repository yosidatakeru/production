using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �V�[���̐؂�ւ� (���̃V�[���̖��O���w��)
            SceneManager.LoadScene("GameScene"); // "NextSceneName" ��؂�ւ������V�[�����ɕύX
        }
    }
}
