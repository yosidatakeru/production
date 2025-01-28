using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboScript : MonoBehaviour
{
    private TMP_Text scoreText;

    ComboSceorwScript comboSceorwScript;
    // Start is called before the first frame update
    void Start()
    {
        comboSceorwScript = GameObject.Find("ComboScore (TMP)").GetComponent<ComboSceorwScript>();
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (comboSceorwScript.conboScore != 0)
        {
            scoreText.text =  "COMBO";
        }
    }
}
