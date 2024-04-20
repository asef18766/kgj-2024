
using System.Collections;
using System.Collections.Generic;
using System;
using GameAssets.Scripts.QTE;
using UnityEngine;
public class EmployeeController : MonoBehaviour
{
    public GameDataScriptableObject gameDataValues;
    [SerializeField] private QTEController qteController;

    private void _onQTEResult(bool res)
    {
        Debug.Log($"QTE {res}");
        StartCoroutine(WaitForAnimation());
    }

    private IEnumerator WaitForAnimation()
    { 
        Debug.Log($"current child cnt {qteController.transform.childCount}");
        yield return new WaitUntil(() => qteController.transform.childCount == 0);
        gameDataValues.tmpScore += 5;
        gameDataValues.isWorking = false;
        qteController.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        qteController.IsQTESuccess = _onQTEResult;
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
        if (gameDataValues.isWorking)
            return;
        gameDataValues.isWorking = true;
        qteController.gameObject.SetActive(true);
    }
}
