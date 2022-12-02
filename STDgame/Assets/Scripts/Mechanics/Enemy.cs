
using System;
using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using Platformer.Mechanics;
using Unity.VisualScripting;
using UnityEngine;
using static Platformer.Core.Simulation;

public class Enemy : MonoBehaviour
{
    public enum MoveDir
    {
        UP_DOWN,
        LEFT_RIGHT
    }

    public MoveDir moveDirection;
    
    private Vector3 _startPosition;
    
    public float distance = 0;
    
    public float speed = 0;
    
    public Bounds Bounds => _collider.bounds;

    public AnimationController control { get; set; }
    public Collider2D _collider { get; set; }
    public AudioSource _audio { get; set; }
    public AudioClip ouch { get; set; }

    private bool down = false;
    private bool left = false;


    void Start()
    {
        _startPosition = transform.localPosition;
        control = GetComponent<AnimationController>();
        _collider = GetComponent<Collider2D>();
        _audio = GetComponent<AudioSource>();
        ouch = GetComponent<AudioClip>();
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            var ev = Schedule<PlayerEnemyCollision>();
            ev.player = player;
            ev.enemy = this;
        }
    }

    public void UpDown()
    {
        if (!down)
        {
            transform.localPosition += Time.deltaTime * speed * Vector3.up;
            if (transform.position.y >= _startPosition.y + distance)
            {
                down = true;
            }
        }
        else
        {
            transform.localPosition += Time.deltaTime * speed * Vector3.down;
            if (transform.position.y < _startPosition.y)
            {
                down = false;
            }
        }
    }
    
    public void LeftRight()
    {
        if (!left)
        {
            transform.localPosition += Time.deltaTime * speed * Vector3.right;
            if (transform.position.x >= _startPosition.x + distance)
            {
                left = true;
            }
        }
        else
        {
            transform.localPosition += Time.deltaTime * speed * Vector3.left;
            if (transform.position.x < _startPosition.x)
            {
                left = false;
            }
        }
    }

    void Update()
    {
        if (moveDirection == MoveDir.UP_DOWN)
        {
            UpDown();
        }else if(moveDirection == MoveDir.LEFT_RIGHT)
        {
            LeftRight();
        }
        
    }
    
    
    
}
