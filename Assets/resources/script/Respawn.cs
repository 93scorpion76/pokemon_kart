using System;
using UnityEngine;
using UnityStandardAssets.Utility;
using UnityStandardAssets.Vehicles.Car;

public class Respawn : MonoBehaviour {

    private const double TIME_RESPAWN = 3.0;
    private DateTime timeRespawn;
    private bool isInactive = false;

    public bool isSea = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isSea)
        {
            if ((int)this.gameObject.GetComponent<CarController>().CurrentSpeed == 0)
            {

                if (!isInactive)
                {
                    timeRespawn = DateTime.Now;
                    timeRespawn = timeRespawn.AddSeconds(TIME_RESPAWN);
                    isInactive = true;
                }
                else
                {
                    if (DateTime.Compare(timeRespawn, DateTime.Now) < 0)
                    {
                        respawn(this.gameObject);
                        isInactive = false;
                    }
                }
            }
            else
            {
                if (isInactive && DateTime.Compare(timeRespawn, DateTime.Now) < 0)
                {
                    isInactive = false;
                }

            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (isSea)
        {
            if (other.gameObject.tag == "Vehicle")
            {
                respawn(other.gameObject.transform.parent.gameObject);
            }
        }
    }

    private void respawn(GameObject vehicle)
    {
         GameObject circuit = GameObject.Find("Circuit_1");
         Vector3 nearLocation = Vector3.zero;
         float lastDist = float.NaN;
         int index = -1;
         int indexNearWaypoint = -1;
         foreach (Transform waypoint in circuit.GetComponent<WaypointCircuit>().Waypoints)
         {
             if (lastDist.Equals(float.NaN))
             {
                 nearLocation = waypoint.transform.position;
                 lastDist = Vector3.Distance(waypoint.position, vehicle.gameObject.transform.position);
                 index = 0;
                 indexNearWaypoint = index;
             }
             else if (lastDist > Vector3.Distance(waypoint.position, vehicle.gameObject.transform.position))
             {
                 nearLocation = waypoint.transform.position;
                 lastDist = Vector3.Distance(waypoint.position, vehicle.gameObject.transform.position);
                 indexNearWaypoint = index;

             }
             index++;
         }
         vehicle.transform.position = nearLocation;
         vehicle.transform.rotation = new Quaternion(0, 0, 0, 0);

        if (circuit.GetComponent<WaypointCircuit>().Waypoints.Length > indexNearWaypoint + 1)
            vehicle.transform.LookAt(circuit.GetComponent<WaypointCircuit>().Waypoints[indexNearWaypoint + 1]);
        else
            vehicle.transform.LookAt(circuit.GetComponent<WaypointCircuit>().Waypoints[0]);
        
        vehicle.GetComponent<Rigidbody>().velocity = vehicle.transform.forward * 5.0f;
    }
}
