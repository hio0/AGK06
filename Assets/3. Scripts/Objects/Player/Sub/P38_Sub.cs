using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P38_Sub : MonoBehaviour, ISubWeapon
{
    public Transform shotpoint {  get; set; }

    public float subdamage { get; set; }

    public float subspeed { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Used()
    {
        Instantiate(gameObject, shotpoint.position, gameObject.transform.rotation);
    }
}
