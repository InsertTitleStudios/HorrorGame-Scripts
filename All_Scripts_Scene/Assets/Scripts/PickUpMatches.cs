using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickUpMatches : MonoBehaviour
{
    public int _matchesAmount = 1;
    public bool inZone = false;

  void OnTriggerEnter(Collider mat)
    {
        if (mat.tag == "Player")
        {
            inZone = true;
        }
    }

    void OnTriggerExit(Collider mat)
    {
        if (mat.tag == "Player")
        {
              inZone = false;
        }
    }

    public void AddMatch()
    {
        Checkpoint temp = GameObject.FindGameObjectWithTag("Checkpoint").
        GetComponentInChildren<Checkpoint>();
        temp.AddMatches(_matchesAmount);
        Destroy(gameObject);
    }
}

	
