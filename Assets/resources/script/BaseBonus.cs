using System;
using UnityEngine;

public class BaseBonus : MonoBehaviour
{
    public String name { get; set; }
    public GameObject parent { get; set; }

    public bool useAbility = false;
    protected bool startAbility = false;

    public void UseAbility()
    {
        useAbility = true;
    }
}