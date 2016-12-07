﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;   
    private FirstPersonController player;
    public Checkpoint match;
    [HideInInspector]
    public List<PickUpMatches> tempPickedUpMatches;
   // public List<PickUpMatches> permPickedUpMatches;

    void Start ()
    { player = FindObjectOfType<FirstPersonController>();
        match = FindObjectOfType<Checkpoint>();
    }
	
    public void RespawnPlayer()
    { Debug.Log("Respawned Player");
      player.transform.position = currentCheckpoint.transform.position;
        match.respawn = true;

        for (int i = tempPickedUpMatches.Count - 1; i >= 0; i--)
        {
            if (tempPickedUpMatches[i].checkpointActivated && tempPickedUpMatches[i].pickedUp)
            {

            }
            else
            {
                tempPickedUpMatches[i].gameObject.SetActive(true);
                tempPickedUpMatches[i].pickedUp = false;
                tempPickedUpMatches.Remove(tempPickedUpMatches[i]);
            }
        }


        
        //pickup matches checkpoint saved bool = true 

    } }


