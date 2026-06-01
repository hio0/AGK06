using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerFly me;
    public GameObject shotpoint;

    public Transform heartPos;
    public GameObject life;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<HitBox>().hp = me.hp;
    }

    // Update is called once per frame
    void Update()
    {
        int hp = gameObject.GetComponent<HitBox>().hp;
        if (heartPos.childCount != hp)
        {
            int chai = hp - heartPos.childCount;
            
            if(chai > 0) // hp가 증가함
            {
                for (int i = 0; i < hp; i++)
                {
                    Instantiate(life, heartPos);
                }
            }
            else // hp가 감소됨
            {
                for (int i = heartPos.childCount; i > hp; i--)
                {
                    Destroy(heartPos.GetChild(i));
                }
            }
        }

        if(hp >= 5)
        {
            hp = 5;
        }
    }
}
