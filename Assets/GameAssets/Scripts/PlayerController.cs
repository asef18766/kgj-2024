
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class PlayerController : MonoBehaviour
{

    private float horizontalInput = 0;
    private float verticalInput = 0;
    private Rigidbody rb;
    public GameDataScriptableObject gameDataValues;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (gameDataValues.isWorking)
        {
            horizontalInput = 0;
            verticalInput = 0;
        }

        rb.velocity = new Vector3(gameDataValues.speed * horizontalInput, 0, gameDataValues.speed * verticalInput);
    }
}
