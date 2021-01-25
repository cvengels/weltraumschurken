using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShotController : MonoBehaviour
{
    Rigidbody2D shot;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        shot = GetComponent<Rigidbody2D>();
        shot.velocity = new Vector2(0,- speed);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("trigger");
        if (collision.gameObject.tag == "Player")
        {

            Debug.Log("hit");
            Destroy(gameObject);
            Destroy(collision.gameObject);
            // add points

        }
    

    }
}
