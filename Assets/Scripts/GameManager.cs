using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int playerScore = 0;
    private int playerLives = 3;
      
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addLives(int value)
    {
        playerLives += value;
        if (playerLives <= 0)
        {
            Debug.Log("Game over!");
            playerLives = 0;
        }

        Debug.Log("Lives: " + playerLives);
    }

    public void addScore(int value)
    {
        playerScore += value;
        Debug.Log("Score: " + playerScore);
    }
}
