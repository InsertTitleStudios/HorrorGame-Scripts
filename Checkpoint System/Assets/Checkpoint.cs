using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    public LevelManager levelManager;
    public static int _currentMatches = 3;
    public bool inZone = false;

    // Use this for initialization
    void Start()
    { levelManager = FindObjectOfType<LevelManager>(); }

    // Update is called once per frame
    void Update ()
    { if (Input.GetKeyDown(KeyCode.F) && inZone)
        { if (_currentMatches >= 1)
            { levelManager.currentCheckpoint = gameObject;
              Debug.Log("Activated Checkpoint" + transform.position); //Add gui label text display "CheckPoint activated"
              _currentMatches--;
                Debug.Log("You have this many matches left");
                print(_currentMatches); }

          else if (_currentMatches <=0)
            { _currentMatches = 0;
             Debug.Log("You have no matches go collect matches"); }}} // put code for when player has no matches - GUI Lavel text display "Find Matches to activate checkpoint"
    
    public void OnTriggerEnter(Collider other)  
    { if (other.name == "Player")
        { inZone = true;
         /* Debug.Log("In checkpoint zone press f to activate");*/ }}

    public void OnTriggerExit(Collider other)
    { if (other.name == "Player")
        { inZone = false;
          /*Debug.Log("I'm out of checkpoint zone");*/ }}

    public void AddMatches (int _matchesAmount) //haven't setup adding matches to current total as of yet -- Only updates checkpoint (1) never updates original checkpoint
    { _currentMatches += _matchesAmount;
        Debug.Log("You have added this match to your amount");
        print(_matchesAmount);
        Debug.Log("You have now this amount of matches");
        print(_currentMatches); }

    public void CheckCheckPoint()
    {
        // If player is in a checkpoint make it so they can't activate that particular checkpoint again until they've changed to a new checkpoint.
    }

}


//Switches checkpoints fine matches deduct fine however each checkpoints seems to have a virtual amount and subtracts from that amount instead of updating the main total
//i.e checkpoint 1 & 2 have 3 matches total what should happen is player walks into checkpoint 1, presses f and it subtracts 1 match currentmatches variable by 1 e.g. 3 - 1 = 2 and there will be 2 matches that can only be used in checkpoints
//what instead is happening is: player walks into checkpoint 1 preses f. subtracts 1 match from checkpoint total 3-1 = 2 however checkpoint 2 still has a total of 3 & when palyer interacts with checkpoint 2 it will subtract match from there and not update amount of matches