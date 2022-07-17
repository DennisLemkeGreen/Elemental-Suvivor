using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    private SpriteRenderer gun;
    private Sprite GunSprite;
    private bool isCooldown = false;
    private float cooldowntTmer = 0.0f;
    [SerializeField] private weaponControler wm;

    private SpriteRenderer sp;

    private float attackSpeed;// = gun.GetComponent<Gun>().attackSpeed;
    void Start()
    {
        sp = bulletPrefab.GetComponent<SpriteRenderer>();
        gun = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        // shoot every attackSpeed seconds
        if(isCooldown){
            applyCooldown();
        }
        else if(Input.GetButtonDown("Fire1")){
            Shoot();
            isCooldown = true;
            cooldowntTmer = attackSpeed;
        } else if (Input.GetButtonDown("Fire2"))
        {
            ChangeWeapon();
        }
    }

    void Shoot(){
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void ChangeWeapon()
    {
        wm.SetArms(Random.Range(0,6), Random.Range(0, 8));
        gun.sprite = wm.currentWeapon;
        bulletPrefab = wm.GetProjectilePrefab();

        Debug.Log(wm.currentProjectile + " " + wm.weaponType);
    }

    private void applyCooldown(){
        cooldowntTmer -= Time.deltaTime;
        if(cooldowntTmer <= 0){
            isCooldown = false;
        }
        
    }
    // private bool isOnCooldown(){
    //     if (isCooldown){
    //         return false;
    //     }
    //     else{
    //         isCooldown = true;
    //         cooldowntTmer = attackSpeed;
    //         return true;
    //     }
    // }
}
