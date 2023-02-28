using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class LevelParser : MonoBehaviour
{
    public string filename;
    public GameObject rockPrefab;
    public GameObject brickPrefab;
    public GameObject questionBoxPrefab;
    public GameObject stonePrefab;
    public GameObject waterPrefab;
    public Transform environmentRoot;
    public float blockSpacing = 5.5f;

    //public TextMeshProUGUI test;

    // --------------------------------------------------------------------------
    void Start()
    {
        
        LoadLevel();
    }

    // --------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
    }

    // --------------------------------------------------------------------------
    private void LoadLevel()
    {
        string fileToParse = $"{Application.dataPath}{"/Resources/"}{filename}.txt";
        Debug.Log($"Loading level file: {fileToParse}");

        Stack<string> levelRows = new Stack<string>();

        // Get each line of text representing blocks in our level
        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                levelRows.Push(line);
            }

            sr.Close();
        }

        // Go through the rows from bottom to top
        int row = 0;
        while (levelRows.Count > 0)
        {
            string currentLine = levelRows.Pop();

            char[] letters = currentLine.ToCharArray();
            for (int column = 0; column < letters.Length; column++)
            {
                var letter = letters[column];
                if (letter == 'x')
                {
                    Vector3 rockLocation = new Vector3(column*blockSpacing, row*blockSpacing, 0);
                    //Debug.Log(rockLocation);
                    Instantiate(rockPrefab,rockLocation, Quaternion.identity);
                    
                }
                else if (letter == 'b')
                {
                    Vector3 brickLocation = new Vector3(column * blockSpacing, row * blockSpacing, 0);
                    //Debug.Log(brickLocation);
                    Instantiate(brickPrefab, brickLocation, Quaternion.identity);
                }
                else if (letter == 's')
                {
                    Vector3 stoneLocation = new Vector3(column * blockSpacing, row * blockSpacing, 0);
                    //Debug.Log(stoneLocation);
                    Instantiate(stonePrefab, stoneLocation, Quaternion.identity);
                }
                else if (letter == '?')
                {
                    Vector3 questionLocation = new Vector3(column * blockSpacing, row * blockSpacing, 0);
                    //Debug.Log(questionLocation);
                    Instantiate(questionBoxPrefab, questionLocation, Quaternion.identity);
                }
                else if (letter == 'w')
                {
                    Vector3 waterLocation = new Vector3(column * blockSpacing, row * blockSpacing, 0);
                    Instantiate(waterPrefab, waterLocation, Quaternion.identity);
                }
                // Todo - Instantiate a new GameObject that matches the type specified by letter
                // Todo - Position the new GameObject at the appropriate location by using row and column
                // Todo - Parent the new GameObject under levelRoot
                //column++;
            }

            row++;
        }
    }

    // --------------------------------------------------------------------------
    private void ReloadLevel()
    {
        foreach (Transform child in environmentRoot)
        {
           Destroy(child.gameObject);
        }
        LoadLevel();
    }
}
