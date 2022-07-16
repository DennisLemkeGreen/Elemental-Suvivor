using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    [SerializeField] private Color elementColor;
    [SerializeField] private string elementType;

    public Color ElementColor
    {
        get
        {
            return elementColor;
        }
        set
        {
            elementColor = value;
        }
    }
    public string ElementType
    {
        get
        {
            return elementType;
        }
        set
        {
            elementType = value;
        }
    }
    public InputManager.KeyStatus CurrentInput{get;set;}

    
}
