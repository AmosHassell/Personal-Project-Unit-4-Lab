using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectilesOutOfBounds : MonoBehaviour
{

    private float rightBound = 20;
    private float leftBound = -20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > rightBound)
        {
            Destroy(gameObject);
        }

        if (transform.position.z < leftBound)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
