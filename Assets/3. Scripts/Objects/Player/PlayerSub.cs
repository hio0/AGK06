using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSub : MonoBehaviour
{
    PlayerFly mysub;
    ISubWeapon sub;

    // Start is called before the first frame update
    void Start()
    {
        SetSub();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSub()
    {
        mysub = gameObject.GetComponent<Player>().me;
        sub = mysub.subweapon.GetComponent<ISubWeapon>();

        sub.shotpoint = gameObject.GetComponent<Player>().shotpoint.transform;
        sub.subdamage = mysub.subdamage;
        sub.subspeed = mysub.subspeed;

        SetInput();
    }

    void SetInput()
    {
        InputManager.Inputing.UseSub = sub.Used;
    }
}
