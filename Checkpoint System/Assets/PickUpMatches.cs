using UnityEngine;
using System.Collections;

public class PickUpMatches : MonoBehaviour
{
    public int _matchesAmount = 1;
    public bool inZone = false;
    public float range = 100f;

    public 

    void OnTriggerEnter(Collider mat)
    { if (mat.tag == "Player")
        { inZone = true; } }

    void OnTriggerExit(Collider mat)
    { if (mat.tag == "Player")
        { inZone = false; } }

    void Update()
    { if (Input.GetKeyDown(KeyCode.E) && inZone)
        {
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, range))
            {
                Debug.Log("You are casting a ray");
                Debug.DrawLine(ray.direction, hit.point, Color.red);

                //Debug.DrawLine(hit.point, Color.red);
                Checkpoint temp = GameObject.FindGameObjectWithTag("Checkpoint").
                    GetComponentInChildren<Checkpoint>();
                temp.AddMatches(_matchesAmount);
                Destroy(gameObject); } } } }

	
