using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour {

    private const float TIME_TO_SPAWN = 10.0f;
    private const float TIME_TO_EXIST = 4.0f;
    private DateTime timeToSpawn;

    private bool isLaunch = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!isLaunch)
        {
            timeToSpawn = DateTime.Now;
            timeToSpawn = timeToSpawn.AddSeconds(TIME_TO_SPAWN);
            isLaunch = true;
        }

        if (isLaunch && DateTime.Compare(timeToSpawn, DateTime.Now) < 0) {

            GameObject rock = Instantiate((GameObject)Resources.Load("doodads/Rock", typeof(GameObject)), this.transform.position, this.transform.rotation);
            Destroy(rock, TIME_TO_EXIST);
            isLaunch = false;
        }
    }
}
