using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public Transform player; // reference to the player object

    [SerializeField] private Camera mainCamera; // reference to the main camera

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            // get the y-coordinate of the player position
            float playerY = player.position.y;

            // set the y-coordinate of the raycast hit position to the same as the player
            Vector3 mouseWorldPosition = raycastHit.point;
            mouseWorldPosition.y = playerY;

            // update the position of the object to the mouse position
            transform.position = mouseWorldPosition;
        }
    }
}