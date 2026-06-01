using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerFly : ScriptableObject
{
    [Header("스탯")]
    public string flyname;

    public int hp;
    public float movespeed;

    [Header("기본공격")]
    public BulletData bullet;

    [Header("서브")]
    public GameObject subweapon;
    public int subdamage;
    public float subspeed;

    [Header("포메이션")]
    public GameObject formation;
}
