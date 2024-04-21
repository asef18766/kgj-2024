using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMe : MonoBehaviour
{
    public GameObject target;

    void Start()
    {
        if (target == null)
            target = gameObject;
    }

    public void Close()
    {
        this.target.SetActive(false);
    }
}
