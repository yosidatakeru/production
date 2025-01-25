using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ComboSceorwScript : MonoBehaviour
{
    public int conboScore = 0;
    private TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        conboScore = 0;
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (conboScore != 0)
        {
            scoreText.text = conboScore.ToString();
        }
    }
}
