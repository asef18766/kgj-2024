
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class SeatController : MonoBehaviour
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
            gameDataValues.score += gameDataValues.tmpScore;
            gameDataValues.tmpScore = 0;
            Debug.Log("Seat!");
        }
    }
}
