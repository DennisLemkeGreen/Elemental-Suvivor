using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D),typeof(InputManager))]
public class MainCharacterMovement : MonoBehaviour
{   
    private Rigidbody2D rigidBody;
    private InputManager inputManager;
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isFacingRight = true;
    [SerializeField] private float speed = 5f;
    private bool blockMovement = false;
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
        animator.SetFloat("Speed",Mathf.Abs(Input.GetAxis("Horizontal")*speed));
        animator.SetFloat("Speed",Mathf.Abs(Input.GetAxis("Vertical")*speed));
        if(!blockMovement){
            
            if(Input.GetAxis("Horizontal") != 0f){
                transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime,0f,0f));
                if(Input.GetAxis("Horizontal") > 0f && !isFacingRight){
                    Flip();
                }
                else if(Input.GetAxis("Horizontal") < 0f && isFacingRight){
                    Flip();
                }
            }
            if(Input.GetAxis("Vertical") != 0f){
                transform.Translate(new Vector3(0f,Input.GetAxis("Vertical") * speed * Time.deltaTime,0f));
                
            }
            
        }
            
    }
    
    void Flip(){
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    
}
