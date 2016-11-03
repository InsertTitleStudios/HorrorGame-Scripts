using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Checkpoint : MonoBehaviour {

    public LevelManager levelManager;
    public static int _currentMatches = 3;
    public bool inZone = false;
    public Text matches_text;
    public Text _ActivateCheckpoint_Text;
    public Text _InActiveCheckpoint_Text;
    public Text _CheckpointNoMatches_Text;
    public Text _CheckpointDiscovered_Text;

    // Use this for initialization
    void Start()
    { levelManager = FindObjectOfType<LevelManager>();
        matches_text.text = "X " + _currentMatches;
        _ActivateCheckpoint_Text.text = "Checkpoint Activated";
        _InActiveCheckpoint_Text.text = "Can't Activate Checkpoint Again";
        _CheckpointDiscovered_Text.text = "Checkpoint Discovered \nPress F to activate";
        _CheckpointNoMatches_Text.text = "No Matches To Activate Checkpoint \nGo Find Some";
        _ActivateCheckpoint_Text.GetComponent<Text>().enabled = false;
        _InActiveCheckpoint_Text.GetComponent<Text>().enabled = false;
        _CheckpointNoMatches_Text.GetComponent<Text>().enabled = false;
        _CheckpointDiscovered_Text.GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update ()
    { if (Input.GetKeyDown(KeyCode.F) && inZone && levelManager.currentCheckpoint != gameObject)
        {
            
            //Debug.Log("New Checkpoint found. Press F to activate it");
            if (_currentMatches >= 1)
            { levelManager.currentCheckpoint = gameObject;
              Debug.Log("Activated Checkpoint" + transform.position); //Add gui label text display "CheckPoint activated"
              _currentMatches--;
                matches_text.text = "X " + _currentMatches;
                _ActivateCheckpoint_Text.text = "Checkpoint Activated";
                _CheckpointDiscovered_Text.GetComponent<Text>().enabled = false;
                _ActivateCheckpoint_Text.GetComponent<Text>().enabled = true;
                
                Debug.Log("You have this many matches left: " + _currentMatches);
                //print(_currentMatches);
            }

          else if (_currentMatches <=0)
            { _currentMatches = 0;
             Debug.Log("You have no matches go collect matches"); }
        }
    if (inZone && levelManager.currentCheckpoint != gameObject)
        {
            _CheckpointDiscovered_Text.text = "Checkpoint Discovered \nPress F to activate";
            Debug.Log("New Checkpoint found. Press F to activate it");
        }
    if (inZone && levelManager.currentCheckpoint != gameObject && _currentMatches == 0)
        {
            _CheckpointNoMatches_Text.GetComponent<Text>().enabled = true;
            
            _CheckpointNoMatches_Text.text = "No Matches To Activate Checkpoint \nGo Find Some";
            Debug.Log("You have no matches to activate this checkpoint. Please find some");
           // _CheckpointNoMatches_Text.GetComponent<Text>().enabled = false;
        }
    }
    // put code for when player has no matches - GUI Lavel text display "Find Matches to activate checkpoint"
    
    public void OnTriggerEnter(Collider other)  
    { if (other.name == "Player")
        { inZone = true;
            if (levelManager.currentCheckpoint == gameObject)
            {
                _InActiveCheckpoint_Text.GetComponent<Text>().enabled = true;
                _InActiveCheckpoint_Text.text = "Can't Activate Checkpoint Again";
                
                Debug.Log("Can't activate this checkpoint again");
            }
            else { _CheckpointDiscovered_Text.GetComponent<Text>().enabled = true;
                
            }
          /*Debug.Log("In checkpoint zone press f to activate"); */}}

    public void OnTriggerExit(Collider other)
    { if (other.name == "Player")
        { inZone = false;
            _ActivateCheckpoint_Text.GetComponent<Text>().enabled = false;
            _InActiveCheckpoint_Text.GetComponent<Text>().enabled = false;
            _CheckpointNoMatches_Text.GetComponent<Text>().enabled = false;
            _CheckpointDiscovered_Text.GetComponent<Text>().enabled = false;
            /*Debug.Log("I'm out of checkpoint zone");*/
        }
    }

    public void AddMatches (int _matchesAmount) //haven't setup adding matches to current total as of yet -- Only updates checkpoint (1) never updates original checkpoint
    { _currentMatches += _matchesAmount;
        Debug.Log("You have added this match to your amount: " + _matchesAmount);
        //print(_matchesAmount);
        Debug.Log("You have now this amount of matches: " + _currentMatches);
        /*print(_currentMatches);*/ }

}