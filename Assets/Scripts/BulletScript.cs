using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject hitEffect;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            if(collision.gameObject.TryGetComponent<life>(out life life))
            {
                ScoreManager.instance.AddPoint();
                life.TakeDamage(1); // mudar para o dano depender do tipo de arma
            }

            GameObject effect = Instantiate(hitEffect, transform.position, new Quaternion(0,0,0,0));    // mudar para o dano depender do tipo de arma
            Destroy(effect, 0.15f);
            Destroy(gameObject);
        }

    }
}
