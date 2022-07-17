using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public GameObject gun;
    private bool isCooldown = false;
    private float cooldowntTmer = 0.0f;

    private float attackSpeed;// = gun.GetComponent<Gun>().attackSpeed;
    void Start()
    {   

        
    //     StartCoroutine(waiter());
    // }
    // IEnumerator waiter(){
    //     while (true){
    //         Shoot();
    //         yield return new WaitForSeconds(.3f);
    //     }
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
        }
    }
    void Shoot(){
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        
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
