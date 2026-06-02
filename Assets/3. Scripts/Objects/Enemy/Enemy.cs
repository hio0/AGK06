using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData me;

    public Transform shotpoint;
    public float bulletime;

    // Start is called before the first frame update
    void Start()
    {
        me = gameObject.GetComponent<IEnemy>().enemydata;
        shotpoint = gameObject.transform.GetChild(0).gameObject.transform;

        gameObject.GetComponent<HitBox>().hp = me.hp;
        gameObject.GetComponent<HitBox>().Dyed = gameObject.GetComponent<IEnemy>().Dyed;
        gameObject.GetComponent<Enemy>().bulletime = me.bullet.bulletimer;

        transform.position = new Vector2(UnityEngine.Random.Range(-2.5f, 2.5f), transform.position.y);
    }

    private void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bulletime -= Time.deltaTime;
        if (bulletime <= 0)
        {
            bulletime = 0;

            GameObject b = Instantiate(me.bullet.bullet, shotpoint.position, Quaternion.Euler(0, 0, -180));
            Bullet ballet = b.GetComponent<Bullet>();

            ballet.damage = me.bullet.bulletdamage;
            ballet.movespeed = me.bullet.bulletspeed;

            bulletime = me.bullet.bulletimer;
        }
    }
}
