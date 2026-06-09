using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefultEnemy : MonoBehaviour, IEnemy
{
    public EnemyData enemydata { get; set; }

    float movespeed;
    bool dengjan;
    bool moved;
    Vector3 targetpos;

    // Start is called before the first frame update
    void Start()
    {
        enemydata = gameObject.GetComponent<Enemy>().me;
        movespeed = enemydata.movespeed;
        dengjan = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dengjan)
        {
            Dengjan();
        }
        else
        {
            Moving();
        }
    }

    public void Dengjan()
    {
        targetpos = new Vector3(transform.position.x, 3.5f, 0);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetpos, 1.5f * Time.deltaTime);

        if (transform.position == targetpos)
        {
            dengjan = true;
        }
    }

    public void Moving()
    {
        if (!moved)
        {
            targetpos = new Vector3(Random.Range(-3f, 3f), transform.position.y, transform.position.z);
            moved = true;
        }

        if (moved)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetpos, movespeed * Time.deltaTime);
        }

        if(transform.position == targetpos)
        {
            moved = false;
        }
    }

    public void Dyed()
    {
        GameManager.gm.PlusScore(100);
        Destroy(gameObject);
    }
}
