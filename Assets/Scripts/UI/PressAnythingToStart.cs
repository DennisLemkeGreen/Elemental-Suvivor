using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressAnythingToStart : MonoBehaviour
{
    [SerializeField] GameObject origin;
    [SerializeField] GameObject destiny;

    [SerializeField] Animator anim;

    private float timer = 1f, counter = 1f;
    private bool keyPressed = false;

    private void Start()
    {
        keyPressed = false;
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            //animate logo going up
            anim.SetBool("Enbiggen", false);
            anim.SetBool("Shorten", true);
            navigate();
        }

        if (keyPressed)
        {
            counter -= Time.deltaTime;
        }

        if(counter < 0)
        {
            navigate();
        }
    }

    private void transitionTimer()
    {
        keyPressed = true;
    }

    private void navigate()
    {
        origin.SetActive(false);
        destiny.SetActive(true);
    }
}
