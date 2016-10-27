using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
   
    private FirstPersonController player; 

    // Use this for initialization
    void Start () {

        player = FindObjectOfType<FirstPersonController>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void RespawnPlayer()
    {
        Debug.Log("Respawned Player");
        player.transform.position = currentCheckpoint.transform.position;
        
    }
}
