using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class raycast_test : MonoBehaviour
{
    private float range = 300f;
    public PickUpMatches _Matchbox;
    public GameObject _HandImage;
    public GameObject _CrossHairImage;

    // Update is called once per frame
    void Update ()
    {
        _Matchbox = FindObjectOfType<PickUpMatches>();
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, range))
        {
            Debug.DrawRay(ray.direction, hit.point, Color.red);

            if (hit.collider.tag == "MatchBox")
            {
                _HandImage.SetActive(true);
                _CrossHairImage.SetActive(false);
            }
            else if  (hit.collider.tag != "MatchBox")
            {
                _HandImage.SetActive(false);
                _CrossHairImage.SetActive(true);
            }           
        }

            if (Input.GetButton("Fire1"))
        {
            if (Physics.Raycast(ray, out hit, range))
            {
                Debug.DrawRay(ray.direction, hit.point, Color.red);

                if (hit.collider.tag == "Matchbox")
                {
                    _Matchbox.AddMatch();
                }
                                    
                Debug.Log(hit.transform.name);
            }
        }

    }

  
}
