using UnityEngine;
using System.Collections;

public class BatteryPickUp : MonoBehaviour {

    public int _batteryPowerAmount = 50;
    public bool inZone = false;

    void OnTriggerExit(Collider mat)
    { if (mat.tag == "Player")
        { inZone = false; }}

    void Update()
    { if (Input.GetKeyDown(KeyCode.E) && inZone)
        { Flashlight temp = GameObject.FindGameObjectWithTag("Player").
                  GetComponentInChildren<Flashlight>();
            temp.AddBattery(_batteryPowerAmount);
            Destroy(gameObject); }}

    void OnTriggerEnter(Collider bat)
    { if (bat.tag == "Player")
        { inZone = true; }}}
