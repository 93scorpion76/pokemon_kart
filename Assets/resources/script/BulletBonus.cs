using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBonus : BaseBonus {

    private const float TIME_TO_LIVE = 10.0f;
    private DateTime timeToDeath;
    private Vector3 forward;
    private int force = 50;

    private bool isLaunch = false;

    // Use this for initialization
    void Start () {
        this.name = "Bullet";
        if (this.parent != null)
            this.gameObject.transform.position = this.parent.transform.position + (this.parent.transform.forward*2);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 direction;
        if (useAbility)
        {
            if (!startAbility)
            {
                isLaunch = true;
                this.gameObject.transform.parent = null;
                this.parent.GetComponent<ManageBonus>().bonus = null;

                startAbility = true;
                this.gameObject.GetComponent<Collider>().isTrigger = false;
                this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                //forward = this.parent.transform.forward - (this.parent.transform.up);
                Vector3 forward = this.parent.transform.forward;
                Vector3 up = this.parent.transform.up;

                direction = new Vector3(forward.x, forward.y, forward.z);
                this.gameObject.GetComponent<Rigidbody>().velocity = direction * force;
            } else
            {
                Destroy(this.gameObject, TIME_TO_LIVE);
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Vehicle" && isLaunch)
        {
            collider.gameObject.transform.parent.gameObject.GetComponent<Stun>().StunVehicle();
            Destroy(this.gameObject);
        }

    }
}
