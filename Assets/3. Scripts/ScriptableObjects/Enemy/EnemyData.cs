using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    [Header("스탯")]
    public GameObject enemy;
    public Sprite image;

    public int hp;
    public float movespeed;
    public BulletData bullet;
}
