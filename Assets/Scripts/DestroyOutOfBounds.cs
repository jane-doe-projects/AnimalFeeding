using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;
    private float sideBound = 30;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            // end the game if the animal gets past the player (not needed now because game is extended)
            // Debug.Log("Game over!");
            
            Destroy(gameObject);
            // decrease player score if animal is missed
            gameManager.addScore(-1);
        } else if (transform.position.x > sideBound || transform.position.x < -sideBound)
        {
            Destroy(gameObject);
            gameManager.addScore(-1);
        }
    }
}
