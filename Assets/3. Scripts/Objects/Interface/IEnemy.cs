using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    EnemyData enemydata { get; set; }

    void Moving();

    void Dyed();
}
