using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour
{
    [SerializeField] private float health, maxHealth = 3f;
    public int element;
    GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.FindWithTag("Spawner");
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log(health);
        if(health <= 0)
        {
            go.GetComponent<RandomSpawner>().DecreaseCount();
            Destroy(gameObject); // provavelmente entrar na tela de engame
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.TryGetComponent<PlayerLife>(out PlayerLife life))
            {
                life.TakeDamage();
            }
        }
    }
}
