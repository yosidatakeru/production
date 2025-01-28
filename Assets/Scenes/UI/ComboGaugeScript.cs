using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboGaugeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public  float Gauge = 0;
    public Slider comboGauge;
    CanvasGroup canvasGroup;
   
    void Start()
    {
        // CanvasGroup‚ğŒ»İ‚ÌGameObject‚©‚çæ“¾
        canvasGroup = GetComponent<CanvasGroup>();
       
    }

    // Update is called once per frame
    void Update()
    {
        comboGauge.value= Gauge;

        if (Gauge <= 0)
        {
            canvasGroup.alpha = 0;
           
        }
        else 
        {
            canvasGroup.alpha = 1;
        }

        Gauge --;
       
    }
}
