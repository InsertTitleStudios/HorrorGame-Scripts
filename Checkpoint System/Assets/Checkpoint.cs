using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Checkpoint : MonoBehaviour {

    public LevelManager levelManager;
    public static int _currentMatches = 3;
    public bool inZone = false;
    public Text matches_text;
    public Text _HUD_Text;

    void Start()
    { levelManager = FindObjectOfType<LevelManager>();
        matches_text.text = "X " + _currentMatches;
        _HUD_Text.text = " "; }

    void Update ()
    { if (Input.GetKeyDown(KeyCode.F) && inZone && levelManager.currentCheckpoint != gameObject)
        { if (_currentMatches >= 1)
            { levelManager.currentCheckpoint = gameObject;
              Debug.Log("Activated Checkpoint" + transform.position);
              _currentMatches--;
              matches_text.text = "X " + _currentMatches;
              _HUD_Text.text = "Checkpoint Activated"; // - Make this animated to show for 3 seconds 1.5 seconds 0 opacity to full & 1.5 seconds full opacity to 0.
              //_HUD_Text.text = " ";
              GetComponent<Animation>().Play("_ActivateCheckpoint");
              Debug.Log("You have this many matches left: " + _currentMatches); }

          else if (_currentMatches <=0)
            { _currentMatches = 0;
              Debug.Log("You have no matches go collect matches"); }}

    if (inZone && levelManager.currentCheckpoint != gameObject)
        { _HUD_Text.text = "Checkpoint Discovered \nPress F to activate"; // - Make this animated to show for 3 seconds 1.5 seconds 0 opacity to full & 1.5 seconds full opacity to 0.
           // _HUD_Text.text = " ";
            GetComponent<Animation>().Play("_Checkpoint Discovered");
            Debug.Log("New Checkpoint found. Press F to activate it"); }

    if (inZone && levelManager.currentCheckpoint != gameObject && _currentMatches == 0)
        { _HUD_Text.text = "No Matches To Activate Checkpoint \nGo Find Some"; // - Make this animated to show for 3 seconds 1.5 seconds 0 opacity to full & 1.5 seconds full opacity to 0.
           // _HUD_Text.text = " ";
            GetComponent<Animation>().Play("_CheckpointNoMatches");
            Debug.Log("You have no matches to activate this checkpoint. Please find some"); }}
        
    public void OnTriggerEnter(Collider other)  
    { if (other.name == "Player")
        { inZone = true;
            if (levelManager.currentCheckpoint == gameObject)
            { _HUD_Text.text = "Can't Activate Checkpoint Again"; // - Make this animated to show for 3 seconds 1.5 seconds 0 opacity to full & 1.5 seconds full opacity to 0.
                GetComponent<Animation>().Play("_UnActivateCheckpoint");
                Debug.Log("Can't activate this checkpoint again"); }

            else
            {/* _HUD_Text.text = " ";*/ }
          /*Debug.Log("In checkpoint zone press f to activate"); */}}

    public void OnTriggerExit(Collider other)
    { if (other.name == "Player")
        { inZone = false; }}

    public void AddMatches (int _matchesAmount) 
    { _currentMatches += _matchesAmount;
        Debug.Log("You have added this match to your amount: " + _matchesAmount);
        Debug.Log("You have now this amount of matches: " + _currentMatches); }}