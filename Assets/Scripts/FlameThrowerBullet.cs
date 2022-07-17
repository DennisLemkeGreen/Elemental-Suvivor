using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerBullet : MonoBehaviour
{
    private float timeToLive = 0.75f;
    // detect unity tigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag != "Player")
        {
            

            if(collision.gameObject.TryGetComponent<life>(out life life))
            {
                ScoreManager.instance.AddPoint();
                life.TakeDamage(1); // mudar para o dano depender do tipo de arma
            }

        }
        if(collision.gameObject.tag == "GameBoundaries")
        {
            Destroy(this);
        }

    }
    void Start()
    {
        Destroy(this.gameObject, timeToLive);
    }
}
