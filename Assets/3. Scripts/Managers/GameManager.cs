using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Data
{
    public int stagenum;
    public int lv;
    public int bomb;
}

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public Data data;

    public List<Stage> stages;
    public int hp;
    public int plused;
    public int damaged;

    public int score;

    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
            data = new Data();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlusScore(int a)
    {
        score += a;
    }
}
