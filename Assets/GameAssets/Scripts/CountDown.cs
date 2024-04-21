using System.Collections;
using UnityEngine;

namespace GameAssets.Scripts
{
    public class CountDown : MonoBehaviour
    {
        public int remainTime = 0;
        [SerializeField] private int roundTime = 60;
        private IEnumerator countDown()
        {
            while (remainTime > 0)
            {
                yield return new WaitForSeconds(1);
                remainTime -= 1;
            }
            UnityEngine.SceneManagement.SceneManager.LoadScene("End");
        }

        private void Start()
        {
            remainTime = roundTime;
            StartCoroutine(countDown());
        }
    }
}