using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    
    private Transform spawnzone;
    public GameObject[] enemyPrefabs;
    public int coloumncount;
    public int rowcount;
    private float x;
    private float y;
    public float speed;
    public GameObject laser;
    public float firerate = 1;
    public GameObject[,] enemy;
    private int row = 0;
    private int coloumn = 0;


    




    // Start is called before the first frame update
    void Start()
    {
        spawnzone = GetComponent<Transform> ();
        enemy = new GameObject[rowcount, coloumncount];
        
        for (y = spawnzone.position.y -((float)rowcount/2); y < spawnzone.position.y + (rowcount / 2); y ++)
        {
            


        for (x = spawnzone.position.x - ((float)coloumncount / 2); x < spawnzone.position.x + (coloumncount / 2); x ++)
        {

                
                enemy[row,coloumn] = Instantiate(enemyPrefabs[Random.Range(0, 4)], new Vector2(x, y), Quaternion.identity, transform);
                enemy[row,coloumn].name = "Enemy" + row + "," + coloumn;
                enemy[row, coloumn].GetComponent<enemyController>().setRow(row);
                enemy[row, coloumn].GetComponent<enemyController>().setColoumn(coloumn);
                enemy[row, coloumn].GetComponent<enemyController>().setFireRate(firerate);
                if (row == 0)
                    enemyShot(row, coloumn);
                coloumn++;


        }
            coloumn = 0;
            row++;
            
        }

        

        
         
        

    }
    

    public void enemyShot(int _row, int _coloumn)
    {
        if (_row < rowcount)
        {
            GameObject currentEnemy = enemy[_row, _coloumn];
            currentEnemy.GetComponent<enemyController>().setCanShoot(true);

        }
       
    }

    void FixedUpdate()
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
    public void setFirerate(float rate)
    {
        firerate = rate;
    }

    public float getFirerate()
    {
        
        return firerate;
    }
}
