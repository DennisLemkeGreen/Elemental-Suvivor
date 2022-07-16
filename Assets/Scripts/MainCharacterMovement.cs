using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D),typeof(InputManager))]
public class MainCharacterMovement : MonoBehaviour
{   

    private MousePosition2D mousePosition;
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
        mousePosition = GetComponentInChildren<MousePosition2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        inputManager = GetComponent<InputManager>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }   

    // Update is called once per frame
    void Update()
    {
        
        animator.SetFloat("Speed",Mathf.Abs(Input.GetAxis("Vertical")*speed + Mathf.Abs(Input.GetAxis("Horizontal")*speed)));
        
        if(!blockMovement){
            
            if(Input.GetAxis("Horizontal") != 0f){
                if (isFacingRight){
                    transform.Translate(new Vector3(Input.GetAxis("Horizontal")  * speed * Time.deltaTime,0f,0f));
                }
                else{
                    transform.Translate(new Vector3(Input.GetAxis("Horizontal") * -1  * speed * Time.deltaTime,0f,0f));
                }
            }
            if(Input.GetAxis("Vertical") != 0f){
                transform.Translate(new Vector3(0f,Input.GetAxis("Vertical") * speed * Time.deltaTime,0f));
                
            }
            
        }
            
    }
    void FixedUpdate(){
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (((mouseWorldPosition.x - transform.position.x) < 0 && isFacingRight) || ((mouseWorldPosition.x - transform.position.x) > 0 && !isFacingRight))
        {
            Flip();
        }
    }
    void Flip(){
        isFacingRight = !isFacingRight;
        if (isFacingRight)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
    
}
