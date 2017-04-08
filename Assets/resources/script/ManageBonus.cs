using UnityEngine;

public class ManageBonus : MonoBehaviour
{

    public GameObject bonus = null;
   


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
            UseAbility();


    }

    public void CatchBonus(GameObject b)
    {
        bonus = b;
        bonus.transform.parent = this.gameObject.transform;
        bonus.GetComponent<BaseBonus>().parent = this.gameObject;
    }

    public void UseAbility()
    {

        if (bonus != null)
        {
            if(!bonus.GetComponent<BaseBonus>().useAbility)
                bonus.GetComponent<BaseBonus>().UseAbility();
            
        }
    }
}