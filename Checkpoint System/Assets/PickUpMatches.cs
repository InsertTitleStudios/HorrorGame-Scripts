using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickUpMatches : MonoBehaviour
{
    public int _matchesAmount = 1;
    public bool inZone = false;
    public float range = 300f;

    public Image _HandImage;
    public Image _CrossHairImage;

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

    void Update()
    {
    
    }

    public void AddMatch()
    {
        Checkpoint temp = GameObject.FindGameObjectWithTag("Checkpoint").
        GetComponentInChildren<Checkpoint>();
        temp.AddMatches(_matchesAmount);
        Destroy(gameObject);
    }
}

	
