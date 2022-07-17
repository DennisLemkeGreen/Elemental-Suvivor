using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shortcuts : MonoBehaviour
{
    [SerializeField] GameObject origin;
    [SerializeField] GameObject escDestiny;

    [SerializeField] Animator anim;

    public bool isMainScreen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMainScreen)
            {
                anim.SetBool("Enbiggen", true);
                anim.SetBool("Shorten", false);
            }
            navigate(origin, escDestiny);
        }
    }

    private void navigate(GameObject origin, GameObject destiny)
    {
        origin.SetActive(false);
        destiny.SetActive(true);
    }
}
