using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefultEnemy : MonoBehaviour, IEnemy
{
    public EnemyData enemydata { get; set; }

    float movespeed;

    // Start is called before the first frame update
    void Start()
    {
        enemydata = gameObject.GetComponent<Enemy>().me;
        movespeed = enemydata.movespeed;

        transform.position = new Vector2(Random.Range(-2.5f, 2.5f), transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    public void Moving()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(transform.position.x, 3.5f), 1.5f * Time.deltaTime);
    }

    public void Dyed()
    {
        Destroy(gameObject);
    }
}
