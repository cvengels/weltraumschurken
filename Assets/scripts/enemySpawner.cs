using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

    private Transform spawnzone;
    public GameObject[] enemyPrefabs;
    public int maxspawn;
    private float x;
    private float y;
    


    // Start is called before the first frame update
    void Start()
    {
        spawnzone = GetComponent<Transform> ();
        x = spawnzone.position.x;
        y = spawnzone.position.y;
        

        for (x = spawnzone.position.x - (maxspawn / 2); x <= spawnzone.position.x + (maxspawn / 2); x += 1)
        {
            
            
            Instantiate(enemyPrefabs[Random.Range(0,4)], new Vector2(x, y), Quaternion.identity);


        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
