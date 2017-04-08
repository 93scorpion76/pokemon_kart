using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class GameManager : MonoBehaviour {

    public Text message;
    public Text timerD;

    public GameObject[] vehicles;
    private const int MAX_SPEED = 50;

    private bool isStarted = false;
    private bool vehicleIsLaunch = false;
    private bool isFinish;

    private float time = 0.0f;

    private DateTime timer;
    private const float TIMER_DECOMPT = 5.0f;
    
	// Use this for initialization
	void Start () {

        foreach(GameObject v in vehicles)
        {
            if (v != null)
            {
                v.GetComponent<Respawn>().enabled = false;
                v.GetComponent<CarController>().MaxSpeed = 0;
            }
        }

        
	}
	
	// Update is called once per frame
	void Update () {
		if(isStarted && !vehicleIsLaunch)
        {
            message.text = (timer.Second - DateTime.Now.Second).ToString();
            if(DateTime.Now.CompareTo(timer) > 0)
            {
                message.enabled = false;
                vehicleIsLaunch = true;

                foreach (GameObject v in vehicles)
                {
                    if (v != null)
                    {
                        v.GetComponent<Respawn>().enabled = true;
                        v.GetComponent<CarController>().MaxSpeed = MAX_SPEED;
                    }
                }
            }
        }

        if (vehicleIsLaunch)
        {
            time += Time.deltaTime;
            timerD.text = "Timer : " + time;
        }
	}
    
    public void AddPlayer(GameObject v)
    {
        v.GetComponent<Respawn>().enabled = false;
        v.GetComponent<CarController>().MaxSpeed = 0;
    
        vehicles[vehicles.Length - 1] = v;
        isStarted = true;

        timer = DateTime.Now;
        timer = timer.AddSeconds(TIMER_DECOMPT);
    }
}
