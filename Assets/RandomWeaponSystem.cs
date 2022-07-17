using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomWeaponSystem : MonoBehaviour
{
    [SerializeField] private weaponControler wm;
    [SerializeField] private BulletShooter bs;

    [SerializeField] private Image wImg1;
    [SerializeField] private Image eImg1;

    [SerializeField] private Image wImg2;
    [SerializeField] private Image eImg2;

    [SerializeField] private Image wImg3;
    [SerializeField] private Image eImg3;


    private Sprite currentWeapon;
    private Sprite currentElement;

    private Sprite randomWeapon;
    private Sprite randomElement;

    public Sprite secretWeapon;
    public Sprite secretElement;

    private Sprite nextEnemy;

    int numberOfAvailableTries = 5;
    int elementChoice = 0, weaponChoice = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Iterate()
    {
        //iterate the randomness of the picking round. Find out the enemy to be generated.
        //your weapons
        wm.SetArms(elementChoice, weaponChoice);

        for (int count = 0; count < numberOfAvailableTries; count++)
        {

            //pick 3 weapons and 3 elements
            //one is your current ones
            elementChoice = Random.Range(0, 6);
            weaponChoice = Random.Range(0, 8);

            wm.SetArms(elementChoice, weaponChoice);


            //one is random
            //one is a "risky" one. May contain the exact counter or have a very ineffective choice

        }

        // attributes chosen cards to player
        bs.ChangeWeapon(elementChoice, weaponChoice);
    }

    public void DisplayCards()
    {
        //this funtion will display the cards on the screen
    }

    public void HideCards()
    {
        //this function will hide the cards on the screen
    }

    public void ChangeCard()
    {
        //receive an UI element and switch data according to availability
    }
}
