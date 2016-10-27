using UnityEngine;
using System.Collections;

public class PickUpMatches : MonoBehaviour
{
    public int _matchesAmount = 1;

    void OnTriggerEnter(Collider mat)
    {
        if (Input.GetKeyDown(KeyCode.E) && mat.tag == "Player")
        {
            Checkpoint temp = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Checkpoint>();
    //        temp.OnTriggerEnter(matchesAmount);
            Destroy(gameObject);

        }
    }
}

	
