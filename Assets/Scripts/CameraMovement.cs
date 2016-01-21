using UnityEngine; 
using System.Collections; 

public class CameraMovement : MonoBehaviour 
{ 
    public Transform player; 
    
    public float offsetX = -5; 
    public float offsetZ = 0;
    public float offsetY = 0;
    public float maximumDistance = 2; 
    public float playerVelocity = 10;

    private float movementX;

    private float movementZ;

    // Update is called once per frame 
    
    void Update () 
    { 
        movementX = ((player.transform.position.x + offsetX - this.transform.position.x))/maximumDistance; 
        movementZ = ((player.transform.position.z + offsetZ - this.transform.position.z))/maximumDistance;
        this.transform.position = new Vector3(player.transform.position.x + offsetX, player.transform.position.y + offsetY, player.transform.position.z + offsetZ);
    } 
} 