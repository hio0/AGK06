using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager stage;
    Data data;

    Stage nowstage;

    int wavecount;
    public Transform enemyspon;

    public GameObject gameoverP;
    float gameovercount;
    public TMP_Text gameoverT;
    public GameObject P;

    public TMP_Text alimT;
    public bool isstart;

    public TMP_Text scoreT;


    private void Awake()
    {
        stage = this;
    }

    void Start()
    {
        data = new Data();
        data = GameManager.gm.data;
        data.stagenum = SceneManager.GetActiveScene().buildIndex;
        nowstage = GameManager.gm.stages[data.stagenum];

        int a = GameManager.gm.plused - GameManager.gm.damaged;
        P.GetComponent<HitBox>().hp = P.GetComponent<Player>().me.hp + a;

        StartCoroutine(TextAlim($"MISSION {data.stagenum + 1}", null));
        isstart = false;

        wavecount = 0;
        gameovercount = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (isstart)
        {
            if (wavecount < nowstage.EnemyWave.Count)
            {
                if (enemyspon.childCount == 0)
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

        scoreT.text = GameManager.gm.score.ToString("00000000");
    }

    IEnumerator TextAlim(string t, Action act)
    {
        isstart = false;
        alimT.text = t;

        alimT.GetComponent<RectTransform>().localPosition = new Vector3(300, 0);
        Vector3 targetpos = new Vector3(-300, 0);

        while (alimT.transform.localPosition != targetpos)
        {
            alimT.GetComponent<RectTransform>().localPosition = Vector3.MoveTowards(alimT.GetComponent<RectTransform>().localPosition, targetpos, 0.7f);

            yield return null;
        }

        act?.Invoke();
        isstart = true;
    }

    void NextStage()
    {
        int a = data.stagenum + 1;
        if (a < GameManager.gm.stages.Count && enemyspon.childCount == 0)
        {
            Action act = () =>
            {
                SceneManager.LoadScene(a);
            };

            StartCoroutine(TextAlim("MISSION\nCOMPLETE", act));
        }
    }

    void EnemySpawn()
    {
        GameObject ene = Instantiate(nowstage.EnemyWave[wavecount], new Vector2(0, 9.29f), Quaternion.Euler(0, 0, 0), enemyspon);

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
        P.GetComponent<HitBox>().hp = 1;
    }

    public void NoContinue()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
