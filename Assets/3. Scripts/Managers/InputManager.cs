using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Inputing;

    public Vector2 MovePath;

    public Action Moved;
    public Action UseSub;
    public Action UseFormation;
    [SerializeField] float formationtime;
    float firstformationtime;

    private void Awake()
    {
        if(Inputing == null)
        {
            Inputing = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        firstformationtime = formationtime;
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Move"))
        {
            Moved?.Invoke();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            UseSub?.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePath = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(Input.GetMouseButtonDown(0) && formationtime != 0)
        {
            formationtime = firstformationtime;
            formationtime += Time.deltaTime;

            if(formationtime <= 0)
            {
                formationtime = 0;
                UseFormation?.Invoke();
            }
        }

        
    }
}
