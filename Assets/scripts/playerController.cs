using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{


    private Rigidbody2D player;
    public float speed;
    public float minBound, maxBound;
    public GameObject laser;
    public float firerate;
    private float nextfire;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D> ();

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > minBound && Input.GetKey(KeyCode.A))
            player.velocity = new Vector2(-speed, 0);
        else if (transform.position.x < maxBound && Input.GetKey(KeyCode.D))
            player.velocity = new Vector2(speed, 0);
        else
            player.velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.Space) && Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            float x = transform.position.x;
            float y = transform.position.y;
            Instantiate(laser, new Vector2(x, y), Quaternion.identity);

        }


    }
}
