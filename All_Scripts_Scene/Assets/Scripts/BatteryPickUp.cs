using UnityEngine;
using System.Collections;

public class BatteryPickUp : MonoBehaviour
{

    public int _batteryPowerAmount = 50;
    public bool inZone = false;

    void OnTriggerExit(Collider mat)
    {
        if (mat.tag == "Player")
        { inZone = false; }
    }

    void OnTriggerEnter(Collider mat)
    {
        if (mat.tag == "Player")
        { inZone = true; }
    }

    void Update()
    { }



    public void AddBatteries()
    {
        Flashlight temp = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Flashlight>();
        temp.AddBattery(_batteryPowerAmount);
        Destroy(gameObject);
    }

}


