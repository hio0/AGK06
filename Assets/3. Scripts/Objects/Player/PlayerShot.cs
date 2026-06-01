using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    PlayerFly myshot;
    float bulletime;
    GameObject bullet;
    Transform shotpoint;

    // Start is called before the first frame update
    void Start()
    {
        myshot = gameObject.GetComponent<Player>().me;
        shotpoint = gameObject.GetComponent<Player>().shotpoint.transform;
        bulletime = myshot.bulletimer;
    }

    // Update is called once per frame
    void Update()
    {
        bulletime -= Time.deltaTime;
        if(bulletime <= 0)
        {
            bulletime = 0;
            bullet = myshot.bullet;

            GameObject b = Instantiate(bullet, shotpoint.position, shotpoint.rotation);
            Bullet ballet = b.GetComponent<Bullet>();

            ballet.damage = myshot.bulletdamage;
            ballet.movespeed = myshot.bulletspeed;

            bulletime = myshot.bulletimer;
        }
    }
}
