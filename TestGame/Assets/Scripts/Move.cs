using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float _moveSpeed = 5.0f;
    void Start()
    {
        Movement();
    }

    void Movement()
    {
        var movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * _moveSpeed;
    }
 
    void Update()
    {
        Movement();
    }

    bool isMoving()
    {
        return new Rigidbody2D().velocity.magnitude > 0;
    }
}
