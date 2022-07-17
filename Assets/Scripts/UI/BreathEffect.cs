using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BreathEffect : MonoBehaviour
{
    float timer = 0.5f, counter = 0.0f;
    bool flip = false;
    TMP_Text tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TMP_Text>();
        counter = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if(counter > timer && !flip)
        {
            counter -= Time.deltaTime;
        }
        else
        {
            flip = true;
        }

        if (counter < timer + 0.5f && flip)
        {
            counter += Time.deltaTime;
        }
        else
        {
            flip = false;
        }

        tmp.color = new Vector4(tmp.color.r, tmp.color.g, tmp.color.b, counter);


    }
}
