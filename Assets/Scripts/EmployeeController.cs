
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class EmployeeController : MonoBehaviour
{
    public GameDataScriptableObject gameDataValues;
    public GameObject player;

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

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("lol!");
        if (other.gameObject == player)
        {
            Debug.Log("Help!");
        }
    }
}
