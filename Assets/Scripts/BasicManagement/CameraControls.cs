using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    #region Variables
    
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _sprintSpeed = 10f;

    #endregion
    #region Movement
    void Movement()
    {
        // Getting player input and applying zoom speed
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Zoom") * _speed, Input.GetAxis("Vertical"));

        // Checking for sprint
        if (Input.GetAxis("Sprint") <= 0)
        {
            // Applying normal speed
            input = new Vector3(input.x * _speed, input.y, input.z * _speed);
        }
        else
        {
            // Applying sprint speed
            input = new Vector3(input.x * _sprintSpeed, input.y, input.z * _sprintSpeed);
        }

        // Moving camera
        transform.position += input * Time.deltaTime;
    }
    #endregion
    #region Update
    void Update()
    {
        Movement();
    }
    #endregion
}
