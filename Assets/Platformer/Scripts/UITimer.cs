using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITimer : MonoBehaviour
{

    public TextMeshProUGUI timerText;
    private static int maxTime = 404;
    private int wholeSecond;
    // Start is called before the first frame update
    void Start()
    {
        wholeSecond = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (wholeSecond < maxTime)
        {
            wholeSecond = (int)Mathf.Floor(Time.realtimeSinceStartup);
        }
         

         

         timerText.text = ($"Time:\n {(maxTime-wholeSecond).ToString()}");
    }
}
