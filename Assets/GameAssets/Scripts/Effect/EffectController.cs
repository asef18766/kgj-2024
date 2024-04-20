using System;
using System.Collections;
using System.Linq;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace GameAssets.Scripts.Effect
{
    public class EffectController : MonoBehaviour
    {
        [SerializeField] private GameObject hudSample;
        [SerializedDictionary("effect name", "icon")]
        [SerializeField] private SerializedDictionary<string, Sprite> hudUI;
        [SerializeField] private float duration;
        [SerializeField] private GameDataScriptableObject gameDataScriptableObject;
        [SerializeField] private ManagerData managerData;

        IEnumerator Chaos(GameObject go)
        {
            gameDataScriptableObject.isConfused = true;
            yield return new WaitForSeconds(duration);
            Destroy(go);
            gameDataScriptableObject.isConfused = false;
        }

        IEnumerator UserSpeedUp(GameObject go)
        {
            gameDataScriptableObject.speed *= 2;
            yield return new WaitForSeconds(duration);
            Destroy(go);
            gameDataScriptableObject.speed /= 2;
        }
        
        IEnumerator UserSpeedDown(GameObject go)
        {
            gameDataScriptableObject.speed /= 2;
            yield return new WaitForSeconds(duration);
            Destroy(go);
            gameDataScriptableObject.speed *= 2;
        }
        IEnumerator BossSpeedDown(GameObject go)
        {
            managerData.speed /= 2;
            yield return new WaitForSeconds(duration);
            Destroy(go);
            managerData.speed *= 2;
        }
        IEnumerator BossSpeedUp(GameObject go)
        {
            Debug.Log("boss speed up");
            managerData.speed *= 2;
            yield return new WaitForSeconds(duration);
            Destroy(go);
            managerData.speed /= 2;
        }

        public void AddRandEffect()
        {
            var go = Instantiate(hudSample, transform);
            var idx = (int) Random.Range(0, hudUI.Keys.Count);
            var effect = hudUI.Keys.ToList()[idx];
            go.GetComponent<Image>().sprite = hudUI[effect];
            StartCoroutine(effect, go);
        }
    }
}