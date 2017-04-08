using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Cameras;
using UnityStandardAssets.Utility;

public class SelectPilote : MonoBehaviour {

    public Button pikachuButton;
    public Button salamecheButton;
    public Button carapuceButton;

    public GameObject IHM;
    public GameObject locationSpawn;
    public GameObject directionSpawn;

    public GameObject currentCamera;
    public GameObject nextCamera;

    public Text speed;
    public Text lap;
    public Text timer;

    public string nameMap;
    
    // Use this for initialization
    void Start () {
        pikachuButton.GetComponent<Button>().onClick.AddListener(ChoosePika);
        salamecheButton.GetComponent<Button>().onClick.AddListener(ChooseSala);
        carapuceButton.GetComponent<Button>().onClick.AddListener(ChooseCara);

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void instantiateVehicles(int nbr)
    {
        GameObject g;
        string nameKart = "" ;
        switch (nbr)
        {
            case 1: //Pikachu
                nameKart = "Pikachu/PikachuKart";
                break;
            case 2: //Carapuce
                nameKart = "Carapuce/CarapuceKart";
                break;
            case 3: //Salamèche
                nameKart = "Salamèche/salameche";
                break;
        }


        IHM.SetActive(true);
        locationSpawn.transform.LookAt(directionSpawn.transform);
        g = Instantiate((GameObject)Resources.Load("karts/" + nameKart, typeof(GameObject)), locationSpawn.transform.position, locationSpawn.transform.rotation);
        g.GetComponent<WaypointProgressTracker>().circuit = GameObject.Find("Circuit_1").GetComponent<WaypointCircuit>();
        g.GetComponent<WaypointProgressTracker>().target = g.transform.FindChild("WaypointTargetObject");
        g.GetComponent<DisplaySpeed>().display = speed;
        g.GetComponent<LapsController>().LapsDisplay = lap;
        g.GetComponent<LapsController>().TimerDisplay = timer;
        nextCamera.GetComponent<AutoCam>().SetTarget(g.transform);
        currentCamera.SetActive(false);
        this.gameObject.SetActive(false);
        nextCamera.SetActive(true);
        GameObject.Find(nameMap).GetComponent<GameManager>().AddPlayer(g);
    }


    void ChoosePika()
    {
        instantiateVehicles(1);
    }

    void ChooseCara()
    {
        instantiateVehicles(2);
    }

    void ChooseSala()
    {
        instantiateVehicles(3);
    }


    }
