using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    public int health;
    private BoxCollider2D bc;
    private bool tookDamage = false;
    private float limit = 2.5f, counter = 3;
    private SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        sp = gameObject.GetComponent<SpriteRenderer>();
        health = maxHealth;
    }

    private void Update()
    {
        if (tookDamage)
        {
            bc.enabled = false;
        }
        else
        {
            bc.enabled = true;
        }

        if(counter < 3)
        {
            counter += Time.deltaTime;
        }

        if(counter > limit)
        {
            tookDamage = false;
        }
    }

    public void TakeDamage()
    {
        Debug.Log("notification");
        if (!tookDamage)
        {
            health -= 1;
            counter = 0;
            tookDamage = true;
        }
        if(health <= 0)
        {
            Destroy(gameObject);
        }

        
    }
}
