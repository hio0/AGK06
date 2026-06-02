using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefultEnemy : MonoBehaviour, IEnemy
{
    public EnemyData enemydata { get; set; }

    float movespeed;
    bool startmoveend;
    Vector3 rondompos;
    float stoptimer;

    // Start is called before the first frame update
    void Start()
    {
        movespeed = enemydata.movespeed;
        startmoveend = false;

        RandomPos();
        transform.position = rondompos;
    }

    // Update is called once per frame
    void Update()
    {
        stoptimer -= Time.deltaTime;
        if(stoptimer <= 0)
        {
            Moving();
        }
    }

    public void Moving()
    {
        Vector3 targetpos = Vector3.zero;

        if(!startmoveend)
        {
            targetpos = new Vector3(gameObject.transform.position.x, 3.5f);
        }
        else
        {
            RandomPos();
            targetpos = rondompos;
        }

        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetpos, movespeed * Time.deltaTime);

        float stop = Random.Range(3.5f, 6f);
        stoptimer = stop;

        if (transform.position == new Vector3(gameObject.transform.position.x, 3.5f))
        {
            startmoveend = true;
        }
    }

    public void Dyed()
    {

    }

    void RandomPos()
    {
        rondompos = new Vector2(Random.Range(-2.5f, 2.5f), transform.position.y);
    }
}
