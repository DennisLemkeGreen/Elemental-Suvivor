using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public string elementType;
    public string enemyElementType;
    public string gunTypes;
    public string rarity;
    [SerializeField] private float damageMultiplier;
    Dictionary <string, float> iceTypeEffectiveness = new Dictionary<string, float>()
    {
        {"water", 0.75f},
        {"fire", 1.5f},
        {"grass", 1.5f}
    };
    Dictionary <string, float> poisonTypeEffectiveness = new Dictionary<string, float>()
    {
        {"water", 1.5f},
        {"fire", 0.75f},
        {"grass", 1.5f}
    };
    Dictionary <string, float> vaporTypeEffectiveness = new Dictionary<string, float>()
    {
        {"water", 1.5f},
        {"fire", 1.5f},
        {"grass", 0.75f}
    };
    Dictionary <string, float> fireTypeEffectiveness = new Dictionary<string, float>()
    {
        {"water", 0.75f},
        {"fire", 1f},
        {"grass", 2f}
    };
    Dictionary <string, float> grassTypeEffectiveness = new Dictionary<string, float>()
    {
        {"water", 1.5f},
        {"fire", 2f},
        {"grass", 1f}
    };
    Dictionary <string, float> waterTypeEffectiveness = new Dictionary<string, float>()
    {
        {"water", 1f},
        {"fire", 2f},
        {"grass", 0.75f}
    };
    // get elemental type of the bullet and return the damage multiplier
    public float GetDamageMultiplier(string elementType,string enemyElementType)
    {
        switch (elementType)
        {
            case "ice":
                return iceTypeEffectiveness[enemyElementType];
            case "poison":
                return poisonTypeEffectiveness[enemyElementType];
            case "vapor":
                return vaporTypeEffectiveness[enemyElementType];
            case "fire":
                return fireTypeEffectiveness[enemyElementType];
            case "grass":
                return grassTypeEffectiveness[enemyElementType];
            case "water":
                return waterTypeEffectiveness[enemyElementType];
            default:
                return 1f;
        }
    }
    Dictionary <string, float> rarityEffectiveness = new Dictionary<string, float>()
    {
        {"common", 1f},
        {"uncommon", 1.1f},
        {"rare", 1.2f},
        {"epic", 1.3f},
        {"legendary", 1.5f}
    };
    public float GetRarityMultiplier(string rarity)
    {
        switch (rarity)
        {
            case "common":
                return 1f;
            case "uncommon":
                return 1.1f;
            case "rare":
                return 1.2f;
            case "epic":
                return 1.3f;
            case "legendary":
                return 1.5f;
            default:
                return 1f;
        }
    }
    Dictionary <string, float> gunType = new Dictionary<string, float>()
    {
        {"flamethrower", 1f},
        {"shotgun", 3f},
        {"machinegun", 1f},
        {"katana", 3f},
        {"grandelauncher", 2f},
        {"shuriken",1f},
        {"sniper",5f},
        {"rocketlauncher",4f}
    };
    public float GetGunTypeMultiplier(string gunType)
    {
        switch (gunType)
        {
            case "flamethrower":
                return 1f;
            case "shotgun":
                return 3f;
            case "machinegun":
                return 1f;
            case "katana":
                return 3f;
            case "grandelauncher":
                return 2f;
            case "shuriken":
                return 1f;
            case "sniper":
                return 5f;
            case "rocketlauncher":
                return 4f;
            default:
                return 1f;
        }
    }
    // calculate damage
    public float GetDamage(float damage, string elementType, string enemyElementType, string rarity, string gunType)
    {
        float damageMultiplier = GetDamageMultiplier(elementType, enemyElementType);
        float rarityMultiplier = GetRarityMultiplier(rarity);
        float gunTypeMultiplier = GetGunTypeMultiplier(gunType);
        return damage * damageMultiplier * rarityMultiplier * gunTypeMultiplier;
    }
}
