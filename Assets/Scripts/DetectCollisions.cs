using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public bool isPlayer = false;
    public bool isAnimal = false;
    public bool isFood = false;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if ( (isPlayer && other.GetComponent<DetectCollisions>().isFood) || (isFood && other.GetComponent<DetectCollisions>().isPlayer) )
        {
            // dont do anything
            //Debug.Log("Food and human collided.");
        } else if ( (isPlayer && other.GetComponent<DetectCollisions>().isAnimal) || (isAnimal && other.GetComponent<DetectCollisions>().isPlayer) )
        {
            // Debug.Log("Game over! You have been hit.");
            if (other.CompareTag("Player"))
            {
                gameManager.addLives(-1);
            }


        } else
        {
            // Debug.Log("Else also happened.");
            if (other.CompareTag("Animal"))
            {
                other.GetComponent<AnimalHunger>().FeedAnimal(1);
                Destroy(gameObject);
                //Destroy(other.gameObject);
                // increase player score when food hits animal
                //gameManager.addScore(1);
            }

        }

    }
}
