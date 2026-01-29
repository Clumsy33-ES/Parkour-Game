using System;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currentPosX; // currentPosX is the target x position for the camera to move to. reason we need this is because we want to move the camera to a new room when the player enters a door.
    private Vector3 velocity = Vector3.zero; // Vector3 to store the current velocity of the camera , .zero means the initial velocity is zero.
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;


   private void Update()
    {
        //Fallow player
        transform.position =new Vector3(player.position.x + lookAhead,transform.position.y,transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead,(aheadDistance*player.localScale.x),Time.deltaTime *cameraSpeed);


       // room camera
        //transform.position=Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y,transform.position.z) ,ref velocity, speed); 
       
        //move the camera to the target x position while keeping the y and z the same.
        // SmoothDamp is used to create a smooth transition effect when moving the camera.
        // ref velocity is used to keep track of the current velocity of the camera.
        //new Vector3(currentPosX, transform.position.y,transform.position.z) is the target position for the camera. 
        // this Vector3 means we want to move the camera to currentPosX on the x axis while keeping the y and z the same.

    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x; // set the target x position to the new room's x position. so the camera will move there in update.
    }
}
