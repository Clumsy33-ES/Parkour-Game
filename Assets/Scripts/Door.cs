using UnityEngine;

public class Door : MonoBehaviour
{
    private CameraController cam;
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
   
     private void Awake()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "Player")
        {
            // if the player is on the left side of the door, and transform.position.x is the door's position, collision is the player.
            // we know transform.position.x is the door's position cause it's not specified otherwise the reason is this script is attached to the door.
            if(collision.transform.position.x < transform.position.x)
            {
               cam.MoveToNewRoom(nextRoom); 
            }
            else 
                cam.MoveToNewRoom(previousRoom);
            
            
            
        }

    }
    
}
