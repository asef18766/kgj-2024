
using System.Collections;
using System.Collections.Generic;
using System;
using GameAssets.Scripts.QTE;
using UnityEngine;
public class EmployeeController : MonoBehaviour
{
    public GameDataScriptableObject gameDataValues;
    public ManagerData managerData;
    [SerializeField] private QTEController qteController;
    public bool isUp;
    public GameObject markPrefab;
    private GameObject mark;
    private float endTime;

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
            gameDataValues.tmpScore += gameDataValues.scoreIncrease;
            gameDataValues.scoreIncrease = (int)(gameDataValues.scoreIncrease * gameDataValues.scoreMultiplier);
            SoundManager.instance.PlaySound(SoundClip.WorkSuccess);
            managerData.speed *= managerData.speedIncrease;
            qteController.BtnCnt += 1;
            Debug.Log(qteController.BtnCnt);
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
            this.qteController = FindObjectOfType<QTEController>(true);
        }
        if (this.qteController == null)
        {
            Debug.LogWarning("QTEController is null");
        }
        mark = (GameObject)Instantiate(markPrefab, transform.position + new Vector3(0, 1, 0), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > endTime)
        {
            if (isUp)
                endTime = Time.time + gameDataValues.employeeCooldown + UnityEngine.Random.Range(-1, 1);
            else
                endTime = Time.time + gameDataValues.employeeUpTime + UnityEngine.Random.Range(-1, 1);

            isUp = !isUp;
            mark.SetActive(isUp);
        }
    }

    void updateUp()
    {

    }

    void FixedUpdate()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isUp)
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
