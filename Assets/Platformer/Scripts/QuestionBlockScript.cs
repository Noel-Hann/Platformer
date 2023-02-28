using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //public TextMeshProUGUI coinCounter;
    // Start is called before the first frame update
    //public GameObject scoreManager;
    public GameObject manager;
    void Start()
    {
        //coinCounter = GameObject.FindWithTag("coinCounter");
        manager = GameObject.FindWithTag("gameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
       Debug.Log("? block was destroyed");
       //coinCounter.GetComponent<CoinCouning>().coinNumber++;
       manager.GetComponent<ScoreManager>().coinCount++;
       manager.GetComponent<ScoreManager>().points += 100;
    }
}
