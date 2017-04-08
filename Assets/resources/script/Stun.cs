using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class Stun : MonoBehaviour {

    private bool isStun;
    private bool effectStun;

    private const float TIME_TO_STUN = 1f;
    private const float MAX_SPEED = 5f;

    private DateTime timeToStun;
    private float maxSpeed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isStun)
        {
            if(!effectStun)
            {
                maxSpeed = this.gameObject.GetComponent<CarController>().MaxSpeed;
                timeToStun = DateTime.Now;
                timeToStun = timeToStun.AddSeconds(TIME_TO_STUN);
                this.gameObject.GetComponent<CarController>().MaxSpeed = MAX_SPEED;
                effectStun = true;
                this.gameObject.GetComponent<Rotate>().enabled = true;
            }

            if (DateTime.Compare(timeToStun, DateTime.Now) < 0)
            {

                this.gameObject.GetComponent<Rotate>().enabled = false;
                this.gameObject.GetComponent<CarController>().MaxSpeed = maxSpeed;
                isStun = false;
                effectStun = false;
                this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward * 5.0f;
            }
        }
	}

    public void StunVehicle()
    {
        isStun = true;
    }
}
