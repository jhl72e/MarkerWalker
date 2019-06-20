﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playertem : MonoBehaviour
{
    public float moveSpeed;

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector3(h, v, 0) * moveSpeed * Time.deltaTime);
    }
}
