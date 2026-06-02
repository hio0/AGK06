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
        movespeed = enemydata.movespeed;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    public void Moving()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(gameObject.transform.position.x, 3.5f), movespeed * Time.deltaTime);
    }

    public void Dyed()
    {
        Destroy(gameObject);
    }
}
