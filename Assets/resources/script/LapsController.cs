using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Utility;
using UnityStandardAssets.Vehicles.Car;

public class LapsController : MonoBehaviour {

    private List<PointPassage> pointPassages;
    PointPassage currentPassage;
    int pos = 1;

    public Text LapsDisplay = null;
    public Text TimerDisplay = null;

    int nbrLaps = 3;
    int currentLaps = 1;

    bool finish = false;

	// Use this for initialization
	void Start () {
        pointPassages = new List<PointPassage>();
        foreach (Transform pos in GameObject.Find("Circuit_1").gameObject.GetComponent<WaypointCircuit>().Waypoints){
            pointPassages.Add(new PointPassage(pos));
        }
        pointPassages[0].isPassed = true;

        fillLap();
    }
	
	// Update is called once per frame
	void Update () {

        if (!finish)
        {
           // fillTimer();
            if (Vector3.Distance(GetComponent<WaypointProgressTracker>().target.position, pointPassages[pos].transform.position) < 3.0f)
            {
                pointPassages[pos].isPassed = true;
                pos++;

                if (pos >= pointPassages.Count)
                {
                    pos = 0;
                    resetPointPassage();
                    currentLaps++;
                    fillLap();
                    if (currentLaps == nbrLaps)
                    {
                        PointPassage passage = new PointPassage(pointPassages[0].transform);
                        passage.isPassed = false;
                        passage.name = pointPassages[0].name;
                        pointPassages.Add(passage);
                    }
                    else if (currentLaps > nbrLaps)
                    {
                        finish = true;
                        GetComponent<CarController>().MaxSpeed = 0;
                        GetComponent<Respawn>().enabled = false;
                    }
                }
            }

        }
	}

    private void resetPointPassage()
    {
        for(int i = 0; i < pointPassages.Count; i++)
        {
            pointPassages[i].isPassed = false;
        }
    }


    private void fillLap()
    {
        if (LapsDisplay != null)
        {
            LapsDisplay.text = "Lap " + currentLaps + "/" + nbrLaps;
        }
    }

    private void fillTimer()
    {
        if (TimerDisplay != null)
        {
            TimerDisplay.text = "Timer : " + System.DateTime.Now;
        }
    }
}

public class PointPassage
{
    public string name;
    public Transform transform;
    public bool isPassed = false;

    public PointPassage(Transform transform)
    {
        this.transform = transform;
        name = transform.name;
    }


}