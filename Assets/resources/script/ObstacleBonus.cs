using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class ObstacleBonus : BaseBonus {

    private bool enterCollider = false;
    private Vector3 explosionLocation;
	// Use this for initialization
	void Start () {
        this.name = "Obstacle";
        if(this.parent != null)
            this.gameObject.transform.position = this.parent.transform.position - this.parent.transform.forward;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (useAbility)
        {
            if (!startAbility)
            {
                this.gameObject.transform.parent = null;
                this.parent.GetComponent<ManageBonus>().bonus = null;
                
                startAbility = true;
            }
            
           
        }

        if (enterCollider)
        {
            this.gameObject.transform.Translate(this.gameObject.transform.up * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!enterCollider)
        {
            if (collider.gameObject.tag == "Vehicle")
            {
               bool explosable = true;
                if (parent != null)
                {
                    if (parent.gameObject.name == collider.gameObject.transform.parent.gameObject.name)
                    {
                        explosable = false;
                    }
                }

                if (explosable) {
                    explosionLocation = new Vector3(
                        this.transform.position.x,
                        this.transform.position.y + 1.0f,
                        this.transform.position.z
                        );

                    GameObject explosion = Instantiate((GameObject)Resources.Load("particles/explosion", typeof(GameObject)), explosionLocation, this.transform.rotation);
                    enterCollider = true;

                    collider.gameObject.transform.parent.gameObject.GetComponent<Stun>().StunVehicle();

                    Destroy(explosion, 1.25f);
                    Destroy(this.gameObject, 1.0f);
                }
            }

        }

    }
}
