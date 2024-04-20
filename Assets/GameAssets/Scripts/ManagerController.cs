
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class ManagerController : MonoBehaviour
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            gameDataValues.tmpScore = 0;
            Debug.Log("Die!");
        }
    }
}
