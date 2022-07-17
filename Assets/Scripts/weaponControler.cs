using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponControler : MonoBehaviour
{
    /* ORDEM DOS VETORES
     * 1. fogo
     * 2. agua
     * 3. grama
     * 4. vapor
     * 5. veneno
     * 6. gelo
         */

    /* ORDEM DAS ARMAS
     * 1. espadas
     * 2. metralhadora
     * 3. shuriken
     * 4. lanca granadas
     * 5. sniper
     * 6. shotgun
     * 7. bazuka
     * 8. lanca chamas
         */
    
    [Header("Projectile Types")]
    [SerializeField] private Sprite[] Beam = new Sprite[6];
    [SerializeField] private Sprite[] Rocket = new Sprite[6];
    [SerializeField] private Sprite[] Bullet = new Sprite[6];
    [SerializeField] private Sprite[] Grenade = new Sprite[6];
    [SerializeField] private Sprite[] Star = new Sprite[6];
    [SerializeField] private Sprite[] Cloud = new Sprite[6];

    [Header("Weapon Types")]
    [SerializeField] private Sprite[] Sword = new Sprite[6];
    [SerializeField] private Sprite MachineGun;
    [SerializeField] private Sprite Shuriken;
    [SerializeField] private Sprite GrenadeLauncher;
    [SerializeField] private Sprite Sniper;
    [SerializeField] private Sprite Shotgun;
    [SerializeField] private Sprite RocketLauncher;
    [SerializeField] private Sprite FlameThrower;
    [SerializeField] private Sprite Unknown;

    [Header("Base Prefab")]
    [SerializeField] private GameObject BeamPrefab;
    [SerializeField] private GameObject RocketPrefab;
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private GameObject GrenadePrefab;
    [SerializeField] private GameObject StarPrefab;
    [SerializeField] private GameObject CloudPrefab;

    [Header("Element Icons")]
    [SerializeField] private Sprite[] elements = new Sprite[7];

    public int weaponType { get; private set; } = 0;
    public int elementType { get; private set; } = 0;
    public Sprite currentWeapon { get; private set; }
    public Sprite currentProjectile { get; private set; }
    public Sprite currentElement { get; private set; }

    // Determines all variables to update a prefab
    public void SetArms(int element, int weapon)
    {
        if((element >= 6 || element < 0) || (weapon >= 8 || weapon < 0)){
            Debug.Log("Invalid element or weapon type!");
        }

        elementType = element;
        weaponType = weapon;
        currentElement = elements[elementType];

        switch (weaponType)
        {
            case 0:
                currentWeapon = Sword[elementType];
                currentProjectile = Beam[elementType];
                BeamPrefab.GetComponent<SpriteRenderer>().sprite = currentProjectile;
                break;

            case 1:
                currentWeapon = MachineGun;
                currentProjectile = Bullet[elementType];
                BulletPrefab.GetComponent<SpriteRenderer>().sprite = currentProjectile;
                break;

            case 2:
                currentWeapon = Shuriken;
                currentProjectile = Star[elementType];
                StarPrefab.GetComponent<SpriteRenderer>().sprite = currentProjectile;
                break;

            case 3:
                currentWeapon = GrenadeLauncher;
                currentProjectile = Grenade[elementType];
                GrenadePrefab.GetComponent<SpriteRenderer>().sprite = currentProjectile;
                break;

            case 4:
                currentWeapon = Sniper;
                currentProjectile = Bullet[elementType];
                BulletPrefab.GetComponent<SpriteRenderer>().sprite = currentProjectile;
                break;

            case 5:
                currentWeapon = Shotgun;
                currentProjectile = Bullet[elementType];
                BulletPrefab.GetComponent<SpriteRenderer>().sprite = currentProjectile;
                break;

            case 6:
                currentWeapon = RocketLauncher;
                currentProjectile = Rocket[elementType];
                RocketPrefab.GetComponent<SpriteRenderer>().sprite = currentProjectile;
                break;

            case 7:
                currentWeapon = FlameThrower;
                currentProjectile = Cloud[elementType];
                CloudPrefab.GetComponent<SpriteRenderer>().sprite = currentProjectile;
                break;

        }

        return;
    }

    public void PreviewArms(int element, int weapon)
    {
        if ((element >= 6 || element < 0) || (weapon >= 8 || weapon < 0))
        {
            Debug.Log("Invalid element or weapon type!");
        }

        elementType = element;
        weaponType = weapon;
        currentElement = elements[elementType];

        switch (weaponType)
        {
            case 0:
                currentWeapon = Sword[elementType];
                currentProjectile = Beam[elementType];
                BeamPrefab.GetComponent<SpriteRenderer>().sprite = currentProjectile;
                break;

            case 1:
                currentWeapon = MachineGun;
                currentProjectile = Bullet[elementType];
                BulletPrefab.GetComponent<SpriteRenderer>().sprite = currentProjectile;
                break;

            case 2:
                currentWeapon = Shuriken;
                currentProjectile = Star[elementType];
                StarPrefab.GetComponent<SpriteRenderer>().sprite = currentProjectile;
                break;

            case 3:
                currentWeapon = GrenadeLauncher;
                currentProjectile = Grenade[elementType];
                GrenadePrefab.GetComponent<SpriteRenderer>().sprite = currentProjectile;
                break;

            case 4:
                currentWeapon = Sniper;
                currentProjectile = Bullet[elementType];
                BulletPrefab.GetComponent<SpriteRenderer>().sprite = currentProjectile;
                break;

            case 5:
                currentWeapon = Shotgun;
                currentProjectile = Bullet[elementType];
                BulletPrefab.GetComponent<SpriteRenderer>().sprite = currentProjectile;
                break;

            case 6:
                currentWeapon = RocketLauncher;
                currentProjectile = Rocket[elementType];
                RocketPrefab.GetComponent<SpriteRenderer>().sprite = currentProjectile;
                break;

            case 7:
                currentWeapon = FlameThrower;
                currentProjectile = Cloud[elementType];
                CloudPrefab.GetComponent<SpriteRenderer>().sprite = currentProjectile;
                break;

        }

        return;
    }

    public GameObject GetProjectilePrefab()
    {
        switch (weaponType)
        {
            case 0:
                return BeamPrefab;

            case 1:
                return BulletPrefab;

            case 2:
                return StarPrefab;

            case 3:
                return GrenadePrefab;

            case 4:
                return BulletPrefab;

            case 5:
                return BulletPrefab;

            case 6:
                return RocketPrefab;

            case 7:
                return CloudPrefab;

        }

        return BeamPrefab;
    }

}
