using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceStatus : MonoBehaviour
{
    [SerializeField]private int _CurrentLap;
    [SerializeField]private int _CurrentWaypoint;

    [SerializeField] private GameObject[] Waypoints;

    // Start is called before the first frame update
    void Start()
    {
        CurrentLap = 0;
        Waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int CurrentLap
    {
        get
        {
            return this._CurrentLap;
        }
        set
        {
            this._CurrentLap = value;
            this._CurrentWaypoint = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_CurrentWaypoint < Waypoints.Length)
        {
            if (other.gameObject == Waypoints[_CurrentWaypoint])
            {
                _CurrentWaypoint++;
            }
        }

        if (other.gameObject.CompareTag("EndLapGate") && _CurrentWaypoint == Waypoints.Length)
        {
            CurrentLap++;
        }
    }
}
