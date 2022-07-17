using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponControler : MonoBehaviour
{

    [SerializeField] private  GameObject iceBallPrefab;
    [SerializeField] private  GameObject fireBallPrefab;
    [SerializeField] private  GameObject waterBallPrefab;
    [SerializeField] private  GameObject poisonBallPrefab;
    [SerializeField] private  GameObject grassBallPrefab;
    [SerializeField] private  GameObject vaporBallPrefab;

    [SerializeField] private  GameObject iceFlamePrefab;
    [SerializeField] private  GameObject fireFlamePrefab;
    [SerializeField] private  GameObject waterFlamePrefab;
    [SerializeField] private  GameObject poisonFlamePrefab;
    [SerializeField] private  GameObject grassFlamePrefab;
    [SerializeField] private  GameObject vaporFlamePrefab;

    [SerializeField] private  GameObject iceMissilePrefab;
    [SerializeField] private  GameObject fireMissilePrefab;
    [SerializeField] private  GameObject waterMissilePrefab;
    [SerializeField] private  GameObject poisonMissilePrefab;
    [SerializeField] private  GameObject grassMissilePrefab;
    [SerializeField] private  GameObject vaporMissilePrefab;

    [SerializeField] private  GameObject iceGranadePrefab;
    [SerializeField] private  GameObject fireGranadePrefab;
    [SerializeField] private  GameObject waterGranadePrefab;
    [SerializeField] private  GameObject poisonGranadePrefab;
    [SerializeField] private  GameObject grassGranadePrefab;
    [SerializeField] private  GameObject vaporGranadePrefab;

    [SerializeField] private  GameObject iceKatanaPrefab;
    [SerializeField] private  GameObject fireKatanaPrefab;
    [SerializeField] private  GameObject waterKatanaPrefab;
    [SerializeField] private  GameObject poisonKatanaPrefab;
    [SerializeField] private  GameObject grassKatanaPrefab;
    [SerializeField] private  GameObject vaporKatanaPrefab;

    // public GameObject currentWeapon;
    // public GameObject currentBullet;
    // public GameObject currentBulletType;
    // public GameObject currentRarity;
    // public GameObject currentDamage;

    public enum WeaponType
    {
        Shotgun,
        Katana,
        Machinegun,
        Grandelauncher,
        Missilelauncher,
        Sniper
    }
    public enum bulletType
    {
        Flame,
        Ball,
        Missile,
        Granade,
        KatanaSlash
    }
    [System.Serializable]
    public class weapon{
        public string weaponType;
        public float attackSpeed;
        public float attackDamage;
        public string weaponRarity;
    }
    [System.Serializable]
    public class bullet{
        public string bulletType;
        public GameObject bulletPrefab;
    }
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
