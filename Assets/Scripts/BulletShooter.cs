using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    [SerializeField] private UIController uc;
    public float bulletForce = 20f;
    public float projectileSpeed = 1.0f;
    public float bulletDamage;
    public float accuracyFactor = 0.5f;
    public int shotCount = 0;
    private SpriteRenderer gun;
    private Sprite GunSprite;
    private bool isCooldown = false;
    private float cooldowntTmer = 0.0f;
    private float splash = 0;
    [SerializeField] private weaponControler wm;

    private SpriteRenderer sp;

    private float attackSpeed = 0.1f;// = gun.GetComponent<Gun>().attackSpeed;

    void Start()
    {
        sp = bulletPrefab.GetComponent<SpriteRenderer>();
        gun = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        // shoot every attackSpeed seconds
        if (isCooldown) {
            applyCooldown();
        }
        else if (Input.GetButton("Fire1")) {
            Shoot();
            isCooldown = true;
            cooldowntTmer = attackSpeed;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            ChangeWeapon();
        }
    }

    void Shoot(){


        switch (wm.weaponType)
        {
            case 0: //sword
                attackSpeed = 0.25f;
                bulletForce = 0f;
                projectileSpeed = 19f;
                bulletDamage = 4f;
                accuracyFactor = 0.5f;
                shotCount = 1;
                splash = 0;
                break;

            case 1: //mach gun
                attackSpeed = 0.08f;
                bulletForce = 3f;
                projectileSpeed = 23f;
                bulletDamage = 0.4f;
                accuracyFactor = 0.8f;
                shotCount = 1;
                splash = 0;
                break;

            case 2: //shuriken
                attackSpeed = 0.3f;
                bulletForce = 5f;
                projectileSpeed = 19f;
                bulletDamage = 8f;
                accuracyFactor = 0.1f;
                shotCount = 2;
                splash = 0;
                break;

            case 3: //grenade launcher
                attackSpeed = 0.8f;
                bulletForce = 20f;
                projectileSpeed = 9f;
                bulletDamage = 14.6f;
                accuracyFactor = 0.3f;
                shotCount = 1;
                splash = 0.3f;
                break;

            case 4: //sniper
                attackSpeed = 1.2f;
                bulletForce = 20f;
                projectileSpeed = 40f;
                bulletDamage = 100f;
                accuracyFactor = 0f;
                shotCount = 1;
                splash = 0;
                break;

            case 5: //shotgun
                attackSpeed = 0.5f;
                bulletForce = 10f;
                projectileSpeed = 15f;
                bulletDamage = 2f;
                accuracyFactor = 0.7f;
                shotCount = 7;
                splash = 0;
                break;

            case 6: //rocket
                attackSpeed = 1.6f;
                bulletForce = 40f;
                projectileSpeed = 12f;
                bulletDamage = 75f;
                accuracyFactor = 0.3f;
                shotCount = 1;
                splash = 0.7f;
                break;

            //case 7: //flamethrower
                //attackSpeed = 0.01f;
                //bulletForce = 0f;
                //projectileSpeed = 0f;
                //bulletDamage = 1f;
                //accuracyFactor = 0f;
                //shotCount = 1;
                //splash = 1;
                //break;

        }
        //*accuracyFactor * Random.Range(-10, 10)

        for(int i = 0; i < shotCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, new Quaternion(firePoint.rotation.x, firePoint.rotation.y, firePoint.rotation.z, firePoint.rotation.w));
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            bullet.GetComponent<ProjectileGeneric>().element = wm.elementType;
            bullet.GetComponent<ProjectileGeneric>().damage = bulletDamage;
            bullet.GetComponent<ProjectileGeneric>().splashRange = splash;
            rb.AddForce(new Vector3(firePoint.up.x + Random.Range(firePoint.up.x - accuracyFactor, firePoint.up.x + accuracyFactor), firePoint.up.y + Random.Range(firePoint.up.y - accuracyFactor, firePoint.up.y + accuracyFactor), firePoint.up.z) * projectileSpeed, ForceMode2D.Impulse);
        }
    }

    void ChangeWeapon()
    {
        wm.SetArms(Random.Range(0,6), Random.Range(0, 7));
        gun.sprite = wm.currentWeapon;
        bulletPrefab = wm.GetProjectilePrefab();

        uc.SetElementAndWeapon(wm.currentElement, wm.currentWeapon);
    }

    public void ChangeWeapon(int element, int weapon)
    {
        wm.SetArms(element, weapon);
        gun.sprite = wm.currentWeapon;
        bulletPrefab = wm.GetProjectilePrefab();
        
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
