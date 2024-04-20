
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
        StartCoroutine(WaitForAnimation(res));
    }

    private IEnumerator WaitForAnimation(bool res)
    {
        Debug.Log($"current child cnt {qteController.transform.childCount}");
        yield return new WaitUntil(() => qteController.transform.childCount == 0);
        if (res)
        {
            gameDataValues.tmpScore += 5;
            SoundManager.instance.PlaySound(SoundClip.WorkSuccess);
        }
        gameDataValues.isWorking = false;
        qteController.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        qteController.IsQTESuccess = _onQTEResult;
        if (this.qteController == null)
        {
            this.qteController = FindObjectOfType<QTEController>();
        }
        if (this.qteController == null)
        {
            Debug.LogWarning("QTEController is null");
        }
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
            SoundManager.instance.PlaySound(SoundClip.Help);
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
