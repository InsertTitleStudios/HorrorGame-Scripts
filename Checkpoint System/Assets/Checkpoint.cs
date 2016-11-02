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
    { if (Input.GetKeyDown(KeyCode.F) && inZone && levelManager.currentCheckpoint != gameObject)
        {
            //Debug.Log("New Checkpoint found. Press F to activate it");
            if (_currentMatches >= 1)
            { levelManager.currentCheckpoint = gameObject;
              Debug.Log("Activated Checkpoint" + transform.position); //Add gui label text display "CheckPoint activated"
              _currentMatches--;
                Debug.Log("You have this many matches left: " + _currentMatches);
                //print(_currentMatches);
            }

          else if (_currentMatches <=0)
            { _currentMatches = 0;
             Debug.Log("You have no matches go collect matches"); }
        }
    if (inZone && levelManager.currentCheckpoint != gameObject)
        {
            Debug.Log("New Checkpoint found. Press F to activate it");
        }
    if (inZone && levelManager.currentCheckpoint != gameObject && _currentMatches == 0)
        {
            Debug.Log("You have no matches to activate this checkpoint. Please find some");
        }
    }
    // put code for when player has no matches - GUI Lavel text display "Find Matches to activate checkpoint"
    
    public void OnTriggerEnter(Collider other)  
    { if (other.name == "Player")
        { inZone = true;
            if (levelManager.currentCheckpoint == gameObject)
            {
                Debug.Log("Can't activate this checkpoint again");
            }
          /*Debug.Log("In checkpoint zone press f to activate"); */}}

    public void OnTriggerExit(Collider other)
    { if (other.name == "Player")
        { inZone = false;
          /*Debug.Log("I'm out of checkpoint zone");*/ }}

    public void AddMatches (int _matchesAmount) //haven't setup adding matches to current total as of yet -- Only updates checkpoint (1) never updates original checkpoint
    { _currentMatches += _matchesAmount;
        Debug.Log("You have added this match to your amount: " + _matchesAmount);
        //print(_matchesAmount);
        Debug.Log("You have now this amount of matches: " + _currentMatches);
        /*print(_currentMatches);*/ }

}