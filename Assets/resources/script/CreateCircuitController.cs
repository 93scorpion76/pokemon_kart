using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCircuitController : MonoBehaviour {

    private List<GameObject> gameobjects = null;
    private int nb;
    private GameObject g;
    private GameObject parent;

	// Use this for initialization
	void Start () {
        gameobjects = new List<GameObject>();
        nb = 0;
        parent = new GameObject("circuit parent");
        parent.transform.parent = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.X))
        {
            string name = "Waypoint ";
            if(nb > 99)
            {
                name += nb;
            } else if( nb > 9)
            {
                name += "0" + nb;
            } else
            {
                name += "00" + nb;
            }
            
            g = new GameObject(name);
            nb++;

            Vector3 v = new Vector3(
                this.transform.position.x,
                this.transform.position.y,
                this.transform.position.z
                );

            g.transform.position = v;
            //g.transform.parent = parent.transform;
            gameobjects.Add(g);
            Debug.Log(name+ " created!");
        }
	}
}
