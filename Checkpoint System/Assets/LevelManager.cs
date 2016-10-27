using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;   
    private FirstPersonController player; 

    void Start ()
    { player = FindObjectOfType<FirstPersonController>(); }
	
    public void RespawnPlayer()
    { Debug.Log("Respawned Player");
      player.transform.position = currentCheckpoint.transform.position; }}
