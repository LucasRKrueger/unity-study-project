using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float _moveSpeed = 5.0f;    
    float _moveJump = 5f;
    float _fallMultiplier = 2.5f;
    float _lowJumpMultiplier = 2f;
    Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Movement();
    }

    void Movement()
    {
        var movementSpeed = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movementSpeed * Time.deltaTime * _moveSpeed; //need to be like jump, using _rigidbody

        if(Input.GetAxis("Vertical") > 0f) //Infity jump need fix
            _rigidbody.velocity = Vector2.up * _moveJump;

        if (_rigidbody.velocity.y < 0)
            _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (_fallMultiplier - 1) * Time.deltaTime;
        else if (_rigidbody.velocity.y > 0 && !Input.GetButton("Jump"))
            _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (_lowJumpMultiplier - 1) * Time.deltaTime;
    }
 
    void Update()
    {
        Movement();
    }
}
