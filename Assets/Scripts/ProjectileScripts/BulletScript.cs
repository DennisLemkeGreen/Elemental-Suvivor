using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject hitEffect;
    SpriteRenderer sp;
    public float damage;
    ProjectileGeneric pg;
    private int result = 0;
    private const int FIRE = 0, WATER = 1, GRASS = 2, STEAM = 3, POISON = 4, ICE = 5;
    private float multiplier = 0;
    private float SplashRange = 0;

    private void Start()
    {
        sp = gameObject.GetComponent<SpriteRenderer>();
        pg = gameObject.GetComponent<ProjectileGeneric>();
        SplashRange = pg.splashRange;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (SplashRange > 0)
        {
            var hitColliders = Physics2D.OverlapCircleAll(transform.position, SplashRange);
            foreach (var hitCollider in hitColliders)
            {
                if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Projectile")
                {
                    if (collision.gameObject.TryGetComponent<life>(out life life))
                    {
                        //ScoreManager.instance.AddPoint();
                        result = CalculateEffectivity(pg.element, life.element);

                        if (result == 0)
                        // not very effective
                        {
                            multiplier = 0.75f;
                            Debug.Log("It's not very effective...");
                        }
                        else if (result == 1)
                        // fairly effective
                        {
                            multiplier = 1f;
                            Debug.Log("The enemy is hit.");
                        }
                        else if (result == 2)
                        // fairly effective
                        {
                            multiplier = 1.5f;
                            Debug.Log("It's fairly effective.");
                        }
                        else if (result == 3)
                        // super effective
                        {
                            multiplier = 3f;
                            Debug.Log("It's super effective!");
                        }
                        Debug.Log("damage: " + damage);
                        damage = damage * multiplier;
                        life.TakeDamage(damage); // mudar para o dano depender do tipo de arma
                    }

                    GameObject effect = Instantiate(hitEffect, transform.position, new Quaternion(0, 0, 0, 0));    // mudar para o dano depender do tipo de arma
                    Destroy(effect, 0.15f);
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Projectile")
            {
                if (collision.gameObject.TryGetComponent<life>(out life life))
                {
                    //ScoreManager.instance.AddPoint();
                    result = CalculateEffectivity(pg.element, life.element);

                    if (result == 0)
                    // not very effective
                    {
                        multiplier = 0.75f;
                        Debug.Log("It's not very effective...");
                    }
                    else if (result == 1)
                    // fairly effective
                    {
                        multiplier = 1f;
                        Debug.Log("The enemy is hit.");
                    }
                    else if (result == 2)
                    // fairly effective
                    {
                        multiplier = 1.5f;
                        Debug.Log("It's fairly effective.");
                    }
                    else if (result == 3)
                    // super effective
                    {
                        multiplier = 3f;
                        Debug.Log("It's super effective!");
                    }

                    damage = damage * multiplier;
                    life.TakeDamage(damage); // mudar para o dano depender do tipo de arma
                }

                GameObject effect = Instantiate(hitEffect, transform.position, new Quaternion(0, 0, 0, 0));    // mudar para o dano depender do tipo de arma
                Destroy(effect, 0.15f);
                Destroy(gameObject);
            }
        }
    }

    public int CalculateEffectivity(int projectile, int target)
    {

        //========================== NOT VERY EFFECTIVE
        if ((projectile == GRASS || projectile == POISON) && target == FIRE)
        {
            return 0;
        }
        if ((projectile == FIRE || projectile == STEAM) && target == WATER)
        {
            return 0;
        }
        if ((projectile == WATER || projectile == ICE) && target == GRASS)
        {
            return 0;
        }
        //========================== NORMAL
        if ((projectile == FIRE) && target == FIRE)
        {
            return 1;
        }
        if ((projectile == WATER) && target == WATER)
        {
            return 1;
        }
        if ((projectile == GRASS) && target == GRASS)
        {
            return 1;
        }
        //========================== FAIRLY EFFECTIVE
        if ((projectile == STEAM || projectile == ICE) && target == FIRE)
        {
            return 2;
        }
        if ((projectile == ICE || projectile == POISON) && target == WATER)
        {
            return 2;
        }
        if ((projectile == STEAM || projectile == POISON) && target == GRASS)
        {
            return 2;
        }
        //========================== SUPER EFFECTIVE
        if ((projectile == WATER) && target == FIRE)
        {
            return 3;
        }
        if ((projectile == GRASS) && target == WATER)
        {
            return 3;
        }
        if ((projectile == FIRE) && target == GRASS)
        {
            return 3;
        }

        return 0;

    }

    public void UpdateSprite(Sprite newSprite)
    {
        sp.sprite = newSprite;
    }


}
