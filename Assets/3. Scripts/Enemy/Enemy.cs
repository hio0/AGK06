using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemydata;
    float bulletime;

    public Action Moving;

    // Start is called before the first frame update
    void Start()
    {
        bulletime = enemydata.bullet.bulletimer;
    }

    private void FixedUpdate()
    {
        Moving?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        bulletime -= Time.deltaTime;
        if (bulletime <= 0)
        {
            bulletime = 0;

            float y = gameObject.transform.position.y + 0.2f;
            GameObject b = Instantiate(enemydata.bullet.bullet, new Vector2(gameObject.transform.position.x, y), Quaternion.Euler(0, 0, -180));
            Bullet ballet = b.GetComponent<Bullet>();

            ballet.damage = enemydata.bullet.bulletdamage;
            ballet.movespeed = enemydata.bullet.bulletspeed;

            bulletime = enemydata.bullet.bulletimer;
        }
    }
}
