
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

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(SoundClip.AddScore);
            gameDataValues.RefreshScore();
            Debug.Log("Seat!");
        }
    }
}
