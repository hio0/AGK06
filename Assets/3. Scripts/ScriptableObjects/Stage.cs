using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Stage : ScriptableObject
{
    public Material bg;
    public List<EnemyData> EnemyWave;
}
