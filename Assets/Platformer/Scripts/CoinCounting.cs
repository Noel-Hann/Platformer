using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCouning : MonoBehaviour
{
    public TextMeshProUGUI coinCounter;
    public int coinNumber = 0;
    private ScoreManager _scoreManager;

    public GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        _scoreManager = manager.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
       coinNumber = _scoreManager.coinCount;
        coinCounter.text = $"Coins x{coinNumber}";
    }
}
