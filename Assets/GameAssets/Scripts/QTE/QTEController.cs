using System;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace GameAssets.Scripts.QTE
{
    public class QTEController:MonoBehaviour
    {
        [SerializedDictionary("keycode", "picture")]
        [SerializeField] private SerializedDictionary<KeyCode, Sprite> keyUI;
        [SerializeField] private GameObject QTEkeyPrefab;
        public int BtnCnt;
        public Action<bool> IsQTESuccess = null;
        
        private List<KeyCode> QTEKeyList = new();
        private List<GameObject> QTEObjectsList = new();
        private List<KeyCode> keyWhiteList;
        
        private void OnEnable()
        {
            IsQTESuccess = b =>
            {
                Debug.Log($"qte success {b}");
            };
            keyWhiteList = keyUI.Keys.ToList();
            // randomly generate val
            for (var i = 0; i != keyUI.Count; ++i)
            {
                var key = keyUI.Keys.ToList()[Random.Range(0, keyUI.Count - 1)];
                QTEKeyList.Add(key);
                var go = Instantiate(QTEkeyPrefab, transform);
                go.GetComponent<Image>().sprite = keyUI[key];
                QTEObjectsList.Add(go);
            }
        }

        private void OnDisable()
        {
            QTEObjectsList.Clear();
            QTEKeyList.Clear();
        }
        
        private void Update()
        {
            foreach (var keyCode in keyWhiteList)
                if (Input.GetKeyDown(keyCode))
                {
                    if (keyCode == QTEKeyList[0]) // correctly matched
                    {
                        QTEObjectsList[0].GetComponent<QTEBtnEffect>().PlayDesAni(true);
                        QTEObjectsList.RemoveAt(0);
                        QTEKeyList.RemoveAt(0);
                    }
                    else
                    {
                        IsQTESuccess(false);
                        foreach (var go in QTEObjectsList)
                            go.GetComponent<QTEBtnEffect>().PlayDesAni(false);
                    }
                }

            if (QTEKeyList.Count == 0)
                IsQTESuccess(true);
        }
    }
}