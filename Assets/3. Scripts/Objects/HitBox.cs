using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public int hp;

    public Action Dyed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Dyed?.Invoke();
        }
    }

    public void Damaged(int damage)
    {
        hp -= damage;
    }
}
