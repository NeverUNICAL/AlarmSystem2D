using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidbody2D;   
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed*Time.deltaTime,0,0);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed*Time.deltaTime*-1,0,0);
        }
    }
}
