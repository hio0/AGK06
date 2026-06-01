using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLoop : MonoBehaviour
{
    public float movespeed;
    [SerializeField] Renderer map;
    [SerializeField] float mapoffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mapoffset += Time.deltaTime * movespeed;
        map.material.mainTextureOffset = new Vector2(map.material.mainTextureOffset.x, mapoffset);
    }
}
