 using UnityEngine;

public class BonusBox : MonoBehaviour {

    private GameObject bonus;
    private string bonusName;
	// Use this for initialization
	void Start () {
        bonusName = GenerateBonus.Generate();
        RaycastHit hitinfo;
        if (Physics.Raycast(transform.position, -transform.up, out hitinfo))
                gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                hitinfo.point.y + 1.0f,
                gameObject.transform.position.z);
            
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Vehicle") 
        {
            GameObject g = collider.gameObject.transform.parent.gameObject;

            if (g.GetComponent<ManageBonus>().bonus == null)
            {
                bonus = Instantiate((GameObject)Resources.Load("doodads/" + bonusName, typeof(GameObject)));
                g.GetComponent<ManageBonus>().CatchBonus(bonus);
            }
            Destroy(this.gameObject);
        }
    }
        
}
