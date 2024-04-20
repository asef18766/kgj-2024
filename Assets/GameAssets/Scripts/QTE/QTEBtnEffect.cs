using System;
using UnityEngine;

namespace GameAssets.Scripts.QTE
{
    public class QTEBtnEffect : MonoBehaviour
    {
        private Animation _animation;
        private bool _triggerDestroy;
        
        private void Start()
        {
            _animation = GetComponent<Animation>();
        }

        public void PlayDesAni(bool success)
        {
            Debug.Log($"{gameObject.name} is {success}");
            _triggerDestroy = true;
            _animation.Play(success ? "FadingCorrect" : "FadingErr");
        }

        private void Update()
        {
            if (_triggerDestroy && !_animation.isPlaying)
                Destroy(gameObject);
        }
    }
}