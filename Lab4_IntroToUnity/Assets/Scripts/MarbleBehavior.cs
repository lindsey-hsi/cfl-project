﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleBehavior : MonoBehaviour
{
    public float moveSpeed = 15f;
    public float rotateSpeed = 35f;
    
    private float fbInput;
    private float lrInput;
    
    private Rigidbody _rb;
    
    void Start()
    {
        //You'll need to add a rigidbody to the marble first
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        fbInput = Input.GetAxis("Vertical") * moveSpeed;
        lrInput = Input.GetAxis("Horizontal") * rotateSpeed;
        this.transform.Translate(Vector3.forward * fbInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * lrInput * Time.deltaTime);
    }
    
    void FixedUpdate()
    {
        fbInput = Input.GetAxis("Vertical") * moveSpeed;
        lrInput = Input.GetAxis("Horizontal") * rotateSpeed;
        Vector3 rotation = Vector3.up * fbInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rb.MovePosition(this.transform.position + this.transform.forward * fbInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);
    }
    
}
