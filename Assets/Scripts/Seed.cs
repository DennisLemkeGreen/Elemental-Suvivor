using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public string GameSeed;
    public int CurrentSeed = 0;

    private void Awake()
    {
        GameSeed = System.DateTime.Now.Ticks.ToString();
        CurrentSeed = GameSeed.GetHashCode();
        Random.InitState(CurrentSeed);
    }
}
