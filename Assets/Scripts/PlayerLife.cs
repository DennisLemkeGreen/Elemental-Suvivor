using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float health, maxHealth =3f;
    public UnityEvent onDeath, onDamage;
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
            Destroy(gameObject);
            onDeath.Invoke();
        }
        else
        {
            onDamage.Invoke();
        }
    }
}
