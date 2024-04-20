using System;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using GameAssets.Scripts.Effect;
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
        [SerializeField] private float effectProb = 0.2f;
        public int BtnCnt;
        
        public Action<bool> IsQTESuccess = null;
        
        private List<KeyCode> QTEKeyList = new();
        private List<GameObject> QTEObjectsList = new();
        private List<KeyCode> keyWhiteList;

        private void Start()
        {
            keyWhiteList = keyUI.Keys.ToList();
        }
        private void OnEnable()
        {
            // randomly generate val
            for (var i = 0; i != keyUI.Count; ++i)
            {
                var key = keyUI.Keys.ToList()[Random.Range(0, keyUI.Count)];
                QTEKeyList.Add(key);
                var go = Instantiate(QTEkeyPrefab, transform);
                go.GetComponent<Image>().sprite = keyUI[key];
                QTEObjectsList.Add(go);
            }
        }

        private void OnDisable()
        {
            Debug.Log("clean all");
            QTEObjectsList.Clear();
            QTEKeyList.Clear();
        }
        
        private void Update()
        {
            if (QTEKeyList.Count == 0) return;
            
            foreach (var keyCode in keyWhiteList)
                if (Input.GetKeyDown(keyCode))
                {
                    if (keyCode == QTEKeyList[0]) // correctly matched
                    {
                        SoundManager.instance.PlaySound(SoundClip.Hit);
                        QTEObjectsList[0].GetComponent<QTEBtnEffect>().PlayDesAni(true);
                        QTEObjectsList.RemoveAt(0);
                        QTEKeyList.RemoveAt(0);
                    }
                    else
                    {
                        SoundManager.instance.PlaySound(SoundClip.Miss);
                        foreach (var go in QTEObjectsList)
                            go.GetComponent<QTEBtnEffect>().PlayDesAni(false);
                        QTEObjectsList.Clear();
                        QTEKeyList.Clear();
                        IsQTESuccess(false);
                        return;
                    }
                }

            if (QTEKeyList.Count == 0)
            {
                if (Random.Range(0f, 1f) <= effectProb)
                    FindObjectOfType<EffectController>().AddRandEffect();
                IsQTESuccess(true);   
            }

        }
    }
}