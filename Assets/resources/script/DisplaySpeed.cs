using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class DisplaySpeed : MonoBehaviour {

    public Text display;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var speed = this.GetComponent<CarController>().CurrentSpeed;
        
        display.text = ((int)speed).ToString();
    }
}
