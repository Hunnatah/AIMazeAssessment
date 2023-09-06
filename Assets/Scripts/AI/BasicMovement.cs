using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class BasicMovement : MonoBehaviour
{
    #region Variables
    // Component refrences
    private NavMeshAgent _agent;
    private Transform _self;

    // Target object refrence
    private GameObject _moveToObject;
    #endregion
    #region Start
    void Start()
    {
        // Initioalizing component refrences
        _agent = GetComponent<NavMeshAgent>();
        _self = GetComponent<Transform>();
    }
    #endregion
    #region MoveAgentToPoint
    void MoveAgentToPoint(bool isFollowMouse)
    {
        // Create data for raycast
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create variable to store info of hit object
        RaycastHit hitinfo;

        // Fire Raycast
        if (Physics.Raycast(ray.origin, ray.direction, out hitinfo))
        {
            if (isFollowMouse)
            {
                // Reset target object
                _moveToObject = null;

                // Assign target as mouse position
                _agent.destination = hitinfo.point;
            }
            else
            {
                // Assign target as selected gameobject
                _moveToObject = hitinfo.transform.gameObject;
            }
        }
    }
    #endregion
    #region Update
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // On left click move agent to position
            MoveAgentToPoint(true);
        }
        if (Input.GetMouseButton(1))
        {
            // On right click make agent follow selected object
            MoveAgentToPoint(false);
        }

        // Move towards assignted target
        _agent.destination = _moveToObject.transform.position;
    }
    #endregion
}
