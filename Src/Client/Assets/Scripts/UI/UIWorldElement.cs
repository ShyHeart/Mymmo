﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWorldElement : MonoBehaviour
{
    public Transform owner;
    // Start is called before the first frame update
    public float height = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (owner != null)
        {
            this.transform.position = owner.position + Vector3.up * height;
        }

        if (Camera.main !=null)
        {
            this.transform.forward = UnityEngine.Camera.main.transform.forward;
        }
    }
}
