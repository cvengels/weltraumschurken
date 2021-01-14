using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

    private Transform spawnzone;
    public GameObject[] enemyPrefabs;
    public int coloumn;
    public int row;
    private float x;
    private float y;
    private List<GameObject> enemylist = new List<GameObject>();
    public float speed;
    public GameObject laser;
    public float fireRate;
    




    // Start is called before the first frame update
    void Start()
    {
        spawnzone = GetComponent<Transform> ();
        x = spawnzone.position.x;
        y = spawnzone.position.y;
        
        for (y = spawnzone.position.y -(row/2); y < spawnzone.position.y + (row / 2); y ++)
        {

        for (x = spawnzone.position.x - (coloumn / 2); x < spawnzone.position.x + (coloumn / 2); x += 1)
        {

                GameObject enemy = Instantiate(enemyPrefabs[Random.Range(0, 4)], new Vector2(x, y), Quaternion.identity, transform);
                enemy.name = "Enemy" + x + "," + y;

    
               enemylist.Add(enemy);


        }
        }

       // InvokeRepeating("MoveEnemy", 0.1f, 0.1f);

    }

    void MoveEnemy()
    {
    }
    // Update is called once per frame
    void Update()
    {
        
        spawnzone.position += Vector3.right * speed;

        foreach (Transform enemy in spawnzone)
        {
            if (enemy.position.x < -9.5 || enemy.position.x > 9.5)
            {
                speed = -speed;
                spawnzone.position += Vector3.down * 0.5f;
                return;
            }
        }
    }
}
