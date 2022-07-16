using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D),typeof(InputManager))]
public class MainCharacterMovement : MonoBehaviour
{   
    private Rigidbody2D rigidBody;
    private InputManager inputManager;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isFacingRight = true;
    [SerializeField] private float speed = 5f;
    private bool blockMovement = false;
    private Vector3 velocity = Vector3.zero;
    public float Speed { get { return speed; } set { speed = value; } }
    public bool Block{
        get => blockMovement;
        set {
            blockMovement = value;
            if(value)
                rigidBody.velocity = Vector2.zero;
        }
    }

    // Start is called before the first frame update
    void Start()
    {   
        rigidBody = GetComponent<Rigidbody2D>();
        inputManager = GetComponent<InputManager>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }   

    // Update is called once per frame
    void Update()
    {
        if(!blockMovement){
            if(inputManager.HorizontalAxis() != 0f){
                transform.Translate(new Vector3(inputManager.HorizontalAxis() * speed * Time.deltaTime,0f,0f));
                if(inputManager.HorizontalAxis() > 0f && !isFacingRight){
                    Flip();
                }
                else if(inputManager.HorizontalAxis() < 0f && isFacingRight){
                    Flip();
                }
            }
            
        }
            
    }
    public void move(float moveH,float moveV){
        Vector3 targetVelocity = new Vector3(moveH * speed,moveV * speed, rigidBody.velocity.y);
        rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, 0.05f);

    }
    void Flip(){
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    
}
