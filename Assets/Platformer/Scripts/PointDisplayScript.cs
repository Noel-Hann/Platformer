using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointDisplayScript : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplay;
    public int points = 0;
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
        points = _scoreManager.points;
        scoreDisplay.text = $"World 1-1\nPoints: {points}";
    }
}
