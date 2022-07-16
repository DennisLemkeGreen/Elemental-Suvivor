using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public class KeyStatus
    {
        public bool isPressed = false;
        public bool isDown = false;
        public bool isUp = false;
        public KeyStatus()
        {
            isPressed = false;
            isDown = false;
            isUp = false;
        }
        public KeyStatus(bool isPressed, bool isDown, bool isUp)
        {
            this.isPressed = isPressed;
            this.isDown = isDown;
            this.isUp = isUp;
        }
        public KeyStatus(string key)
        {
            isPressed = Input.GetKey(key);
            isDown = Input.GetKeyDown(key);
            isUp = Input.GetKeyUp(key);
        }
    }
    public class MouseButton
    {
        public bool isPressed = false;
        public bool isDown = false;
        public bool isUp = false;
        public MouseButton()
        {
            isPressed = false;
            isDown = false;
            isUp = false;
        }
        public MouseButton(bool isPressed, bool isDown, bool isUp)
        {
            this.isPressed = isPressed;
            this.isDown = isDown;
            this.isUp = isUp;
        }
        public MouseButton(string button)
        {
            isPressed = Input.GetMouseButton(0);
            isDown = Input.GetMouseButtonDown(0);
            isUp = Input.GetMouseButtonUp(0);
        }
    }
    public class MousePosition
    {
        public Vector2 position = Vector2.zero;
        public MousePosition()
        {
            position = Vector2.zero;
        }
        public MousePosition(Vector2 position)
        {
            this.position = position;
        }
    }
    [SerializeField] protected GameObject target;
    
    public GameObject Target { get => target; set => target = value; }
    
    
}
