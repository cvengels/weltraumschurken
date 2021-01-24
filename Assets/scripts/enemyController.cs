using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    private bool canShoot;
    private int row;
    private int coloumn;
    private float firerate;
    public GameObject shot;
    GameObject enemy;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        enemy = this.gameObject; // remove this later
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        
    }

    public void OnDestroy()
    {
        canShoot = false;
        enemy.transform.parent.GetComponent<enemySpawner>().enemyShot(row + 1, coloumn);
    }


    public void setRow(int row)
    {
        this.row = row;
    }

    public void setColoumn(int coloumn)
    {
        this.coloumn = coloumn;
    }

    public void setCanShoot(bool shoot)
    {
        canShoot = shoot;
    }

    public void setFireRate(float rate)
    {
        firerate = rate;
    }
    public void fire()
    {
        firerate = Time.time + firerate;
        enemy.transform.parent.GetComponent<enemySpawner>().setFirerate(firerate);
        Instantiate(shot, new Vector3(transform.position.x, transform.position.y - 0.6f, 0), Quaternion.identity, transform);
    }
  

    // Update is called once per frame
    void Update()
    {
        firerate = enemy.transform.parent.GetComponent<enemySpawner>().getFirerate();
        if (canShoot && Time.time > firerate)
        {

            if (enemy.transform.position.x > player.transform.position.x)
            {
                if (enemy.transform.position.x - player.transform.position.x < 0.25 && enemy.transform.position.x - player.transform.position.x > -0.25)
                {
                    fire();

                }

            }
            else if (player.transform.position.x - enemy.transform.position.x < 0.25 && player.transform.position.x - enemy.transform.position.x > -0.25)
            {
                Debug.Log("Shoot" + enemy.name);
                fire();
            }
        }

       // if (canShoot && Mathf.Lerp(enemy.transform.position.x, player.transform.position.x,0.5f) > 0.1) Differenz lerp mathf ????
      
    }
}
