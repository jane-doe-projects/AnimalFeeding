using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float movementSpeed = 10.0f;
    public GameObject projectilePrefab;

    private float xRange = 20;
    private float zRange = 20;
    private Vector3 pizzaOffset = new Vector3(0, 1, 0); // so Pizza does not spawn on the ground but flies through the air
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // keep Player object within bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        // change Player X position based on key/axis input
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * movementSpeed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * movementSpeed);

        // food projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // launch food from player
            Instantiate(projectilePrefab, transform.position + pizzaOffset, projectilePrefab.transform.rotation);
        }
    }
}
