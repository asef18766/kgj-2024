using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts
{
    public class EndController : MonoBehaviour
    {
        [SerializeField] private GameDataScriptableObject userdata;
        [SerializeField] private EndGameConfig cfg;
        [SerializeField] private GameObject scoreboard;
        [SerializeField] private GameObject returnMenu;
        [SerializeField] private TMP_Text text;
        private static readonly int EndNum = Animator.StringToHash("endNum");

        private void Start()
        {
            GetComponent<Animator>().SetInteger(EndNum, userdata.score >= cfg.goodEndVal ? 1 : 2);

            //change the music based on the score
            if (userdata.score >= cfg.goodEndVal)
            {
                SoundManager.instance.ChangeMusic(9);
            }
            else
            {
                SoundManager.instance.ChangeMusic(8);
            }

        }

        public void DisplayScore()
        {
            if (userdata.score >= cfg.goodEndVal)
            {
                returnMenu.SetActive(true);
            }
            else
            {
                scoreboard.SetActive(true);
                text.text = $"{userdata.score}$";
            }
            GetComponent<AudioSource>().Play();

        }
    }
}