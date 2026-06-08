using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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

    public GameObject gameoverP;
    float gameovercount;
    public TMP_Text gameoverT;
    public GameObject P;

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
        if (wavecount < nowstage.EnemyWave.Count)
        {
            if(enemyspon.childCount == 0 && isready)
            {
                EnemySpawn();
            }
        }
        else
        {
            NextStage();
        }

        if (gameoverP.activeSelf)
        {
            gameovercount -= Time.deltaTime;
            if (gameovercount <= 0)
            {
                gameovercount = 0;
                NoContinue();
            }

            gameoverT.text = $"continue? <size=45>{gameovercount.ToString("F0")}</size>";
        }
    }

    void NewGame()
    {
        data = new Data();

        //data.stagenum = 0;
        SetStage();
    }

    void NextStage()
    {
        data.stagenum++;

        SetStage();
    }

    void SetStage()
    {
        nowstage = stages[data.stagenum];

        SceneManager.LoadScene(data.stagenum);
    }

    void EnemySpawn()
    {
        GameObject ene = Instantiate(nowstage.EnemyWave[wavecount], new Vector2(0, 9.29f), Quaternion.Euler(0,0,0), enemyspon);

        wavecount++;
    }

    public void GameOver()
    {
        gameoverP.SetActive(true);
    }

    public void Continue()
    {
        Debug.Log("나의 용돈을 오락실 게임기에 넣었다.\n<i>거지가 된 기분이다...</i>");

        gameoverP.SetActive(false);
        gameovercount = 10;

        P.SetActive(true);
        P.GetComponent<HitBox>().hp = P.GetComponent<Player>().me.hp;
    }

    public void NoContinue()
    {
        Debug.Log("결과창");
    }
}
