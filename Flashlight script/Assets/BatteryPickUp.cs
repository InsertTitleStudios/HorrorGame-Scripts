using UnityEngine;
using System.Collections;

public class BatteryPickUp : MonoBehaviour {

    public int _batteryPowerAmount = 50;

    void OnTriggerEnter(Collider bat)
    {
        if (bat.tag == "Player")
        {
            Flashlight temp = GameObject.FindGameObjectWithTag("Player").
                GetComponentInChildren<Flashlight>();

            temp.AddBattery(_batteryPowerAmount);
            Destroy(gameObject);
        }
    }

	
}
