using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject startP;
    public GameObject saveslotP;
    public GameObject setplayerP;

    void Initialization()
    {
        startP.SetActive(true);
        saveslotP.SetActive(true);
        setplayerP.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PressStart()
    {
        startP.SetActive(false);


    }
}
