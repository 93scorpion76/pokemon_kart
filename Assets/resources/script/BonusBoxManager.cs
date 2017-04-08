using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBoxManager : MonoBehaviour {

    public List<BonusContainer> bonusContainers;

	// Use this for initialization
	void Start () {
        bonusContainers = new List<BonusContainer>();
        foreach(GameObject o in GameObject.FindGameObjectsWithTag("BonusBox"))
        {
            bonusContainers.Add(new BonusContainer(o));
        }
    }
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < bonusContainers.Count; i++)
        {
            if(bonusContainers[i].gameObject == null && !bonusContainers[i].isUsed)
            {
                bonusContainers[i].initRespawn();
            }
            if(bonusContainers[i].isUsed && bonusContainers[i].timeToRespawn <= DateTime.Now)
            {
                bonusContainers[i].reInstantiate();
            }
        }
	}
}

public class BonusContainer
{
    public GameObject gameObject;
    private Vector3 initialLocation;

    public bool isUsed;
    public DateTime timeToRespawn;
    private const float TIME_WAIT = 20.0f;

    public BonusContainer(GameObject gameObject) {
        this.gameObject = gameObject;
        initialLocation = gameObject.transform.position;
        isUsed = false;
    }

    public void reInstantiate()
    {
        this.gameObject = UnityEngine.Object.Instantiate((GameObject)Resources.Load("doodads/pokeball/Pokeball", typeof(GameObject)), initialLocation, Quaternion.identity);
        isUsed = false;
    }

    public void initRespawn()
    {
        timeToRespawn = DateTime.Now;
        timeToRespawn = timeToRespawn.AddSeconds(TIME_WAIT);
        isUsed = true;

    }
}
