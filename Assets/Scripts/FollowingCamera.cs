using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    private GameObject following;
    public Vector2 minCamPos, maxCamPos;
    private float smoothTime;
    private Vector3 velocity;
    
    // Start is called before the first frame update
    void Start()
    {
        following = GameObject.Find("Phantom");
        velocity = new Vector3(200f, 0f, 0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, following.transform.position.x, ref velocity.x, smoothTime);
        float posY = Mathf.SmoothDamp(transform.position.y, following.transform.position.y, ref velocity.y, smoothTime);

        transform.position = new Vector3(
            Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
            Mathf.Clamp(posY, minCamPos.y, maxCamPos.y),
            transform.position.z) ;
    }
}
