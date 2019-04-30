﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFllow : MonoBehaviour
{
    private Transform target;
    private Vector3 offset;
    private Vector3 velocity;
    private void Update()
    {
        if (target == null&&GameObject.FindGameObjectWithTag("Player")!=null)
        {

            target = GameObject.FindGameObjectWithTag("Player").transform;
            offset = target.transform.position - transform.position;
        }
    }
    private void FixedUpdate()
    {
       if (target != null)
        {
           float posX = Mathf.SmoothDamp(transform.position.x, target.position.x - offset.x, ref velocity.x,0.05f);
            float posY = Mathf.SmoothDamp(transform.position.y, target.position.y - offset.y, ref velocity.y, 0.05f);
            if (posY>transform.position.y)
            transform.position = new Vector3(posX, posY, transform.position.z);
        }
    }

}
