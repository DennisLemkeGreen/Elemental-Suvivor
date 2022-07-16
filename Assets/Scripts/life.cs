using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float health, maxHealth =3f;
    // Start is called before the first frame update
    void Start()
    {
        health =maxHealth;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject); // provavelmente entrar na tela de engame
        }
    }
    
}
