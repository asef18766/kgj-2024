
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class EmployeeController : MonoBehaviour
{
    public GameDataScriptableObject gameDataValues;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            quickTimeEvent();
            Debug.Log("Work!");
        }
    }

    void quickTimeEvent()
    {
        gameDataValues.tmpScore += 5;
    }
}
