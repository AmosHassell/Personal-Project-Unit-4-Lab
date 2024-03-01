using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player1Controller : MonoBehaviour
{
    //the floats that help the fighter move
    public float speed = 5.0f;
    public float horizontalinput;
   
    
    //jump cooldown stuff
    public float jumpCooldown;
    private bool isOnGround = true;

    // This variable will let the fighter move up and down like its actually jumping instead of teleporting
    public Rigidbody playerRB;

    // floats that make sure the fighter doesnt walk out the stage through a boundary
    private float zRange = 12.2f;

    // Fireball
    public GameObject fireballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // code that makes the boundary for the player and enemy
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        // lets you move the fighter left and right
        horizontalinput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * horizontalinput * Time.deltaTime * speed);

        // assigns a key to jumping and lets the fighter jump
        if (Input.GetKeyDown(KeyCode.W) && isOnGround)
        {
            playerRB.AddForce(Vector3.up * 500);
            isOnGround = false;
        }

        // Eventually will be one of the first attacks, but this spawns the fireball. Need to code the spawn position to be slightly infront and for it to move.
        if (Input.GetKeyDown(KeyCode.U))
        {
            Instantiate(fireballPrefab, transform.position, fireballPrefab.transform.rotation);
        }
    }
    void OnCollisionEnter(Collision collision) // this whole thing will set isOnGround to true when touching the ground so that you can't spam jump
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}