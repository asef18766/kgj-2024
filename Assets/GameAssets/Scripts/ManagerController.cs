
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using GameAssets.Scripts.QTE;
public class ManagerController : MonoBehaviour
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
            SoundManager.instance.PlaySound(SoundClip.Catched);
            Debug.Log("Die!");
            gameDataValues.catchedReset();
        }
    }
}
