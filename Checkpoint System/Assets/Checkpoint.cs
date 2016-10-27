using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    public LevelManager levelManager;
    public int _currentMatches = 3;

    // Use this for initialization
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update () {

    
	
	}

    public void OnTriggerEnter(Collider other)  //Switches checkpoints fine however only deducts matches from checkpoint 2. 
                                                //Doesn't deduct matches when collide with other checkpoints.

    // input doesn't work yet i.e. press F to activate matches
    {
        if (other.name == "Player")
        {
            Debug.Log("In checkpoint zone press f to activate");
            if (_currentMatches >= 1)
            {
                Debug.Log("Matches = 3");
                
                    levelManager.currentCheckpoint = gameObject;
                    Debug.Log("Activated Checkpoint" + transform.position);
                    _currentMatches--;
                }
        }
    }

    public void AddMatches (int _matchesAmount) //haven't setup adding matches to current total as of yet
    {
        _currentMatches += _matchesAmount;
    }
}
