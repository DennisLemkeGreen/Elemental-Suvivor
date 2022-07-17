using UnityEngine;

public class FollowPlayer : MonoBehaviour
{   
    public Transform player;
    public float speed = 1f;
    public Vector3 offset;

    void FixedUpdate()
    {   
        Vector3 target = player.position + offset;
        Vector3 current = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
        transform.position = current;
        
        transform.LookAt(player);
    }
}
