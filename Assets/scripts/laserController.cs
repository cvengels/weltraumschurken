using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D laser;


    // Start is called before the first frame update
    void Start()
    {
        laser = GetComponent<Rigidbody2D>();
        laser.velocity = new Vector2(0, speed);

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "enemy")
        {
            
            
            Destroy(gameObject);
            Destroy(collider.transform.parent.gameObject);
            // add points
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
