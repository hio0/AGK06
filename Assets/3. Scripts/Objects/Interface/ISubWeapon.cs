using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubWeapon
{
    Transform shotpoint { get; set; }

    float subdamage { get; set; }

    float subspeed { get; set; }

    void Used();
}
