using System.Collections;
using System.Collections.Generic;
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
    }

    void NewGame()
    {
        data = new Data();

        data.stagenum = 0;
    }

    void NextStage()
    {
        data.stagenum++;
        SceneManager.LoadScene(data.stagenum);
    }
}
