using System;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class SpeedBonus : BaseBonus
{
    private const double TIME_BOOST = 10.0;
    private const float MAX_SPEED = 70.0f;
    private float originSpeed;

    private DateTime timeStop; 

    // Use this for initialization
    void Start () {

        this.name = "Speed";
	}
	
	// Update is called once per frame
	void Update () {
        
        if(useAbility)
        {
            if (!startAbility)
            {
                originSpeed = this.parent.GetComponent<CarController>().MaxSpeed;
                timeStop = DateTime.Now;
                timeStop = timeStop.AddSeconds(TIME_BOOST);

                this.parent.GetComponent<CarController>().MaxSpeed = MAX_SPEED;
                startAbility = true;
            }
            
            if(DateTime.Compare(timeStop, DateTime.Now) < 0)
            {
                this.parent.GetComponent<CarController>().MaxSpeed = originSpeed;

               Destroy(this.gameObject);

            }
        }
	}


}
