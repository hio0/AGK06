using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    [Header("스탯")]
    public Sprite image;

    public int hp;
    public BulletData bullet;
}
