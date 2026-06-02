using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
    Stage nowstage;
    bool isready;
    public TMP_Text stagenumT;
    public MeshRenderer bg;

    int wavecount;
    public Transform enemyspon;

    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        NewGame();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            NextStage();
        }

        if(enemyspon.childCount == 0 && isready)
        {
            EnemySpawn();
        }
    }

    void NewGame()
    {
        data = new Data();

        data.stagenum = 1;
        ResetStage();
        SetStage();
    }

    void NextStage()
    {
        data.stagenum++;

        ResetStage();
        SetStage();
    }

    void ResetStage()
    {
        for (int i = 0; i < enemyspon.childCount; i++)
        {
            Destroy(enemyspon.GetChild(i).gameObject);
        }

        wavecount = 0;
        isready = false;
    }

    void SetStage()
    {
        for(int i = 0;i < enemyspon.childCount;i++)
        {
            Destroy(enemyspon.GetChild(i).gameObject);
        }

        nowstage = stages[data.stagenum - 1];
        stagenumT.text = nowstage.name;
        bg.material = nowstage.bg;
        isready = true;
    }

    void EnemySpawn()
    {
        GameObject ene = Instantiate(nowstage.EnemyWave[wavecount].enemy, enemyspon); 
        ene.GetComponent<IEnemy>().enemydata = nowstage.EnemyWave[wavecount];

        wavecount++;
    }
}
