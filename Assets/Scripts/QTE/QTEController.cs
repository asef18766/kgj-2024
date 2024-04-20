using System;
using System.Collections.Generic;
using UnityEngine;

namespace QTE
{
    public class QTEController:MonoBehaviour
    {
        [SerializeField] private Dictionary<KeyCode, Sprite> keyUI;

        private void OnEnable()
        {
            throw new NotImplementedException();
            //Input.GetKeyDown(())
        }
    }
}