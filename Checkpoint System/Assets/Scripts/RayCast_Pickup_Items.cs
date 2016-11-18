using UnityEngine;
using System.Collections;

public class RayCast_Pickup_Items : MonoBehaviour {

	private float range = 300f;
    public PickUpMatches _Matchbox;
    public GameObject _HandImage;
    public GameObject _CrossHairImage;
    public BatteryPickUp _Battery;
    public bool canHover = false;
   

    // Update is called once per frame
    void Update()
    {
        _Matchbox = FindObjectOfType<PickUpMatches>();
        RaycastHit fireHit;
        RaycastHit hoverHit;
       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       // Ray ray = Camera.main.ViewportPointToRay(new Vector3(0f, 0.5f, 0.0f));

        if (Physics.Raycast(ray, out hoverHit, range))
        {
            Debug.DrawRay(ray.direction, hoverHit.point, Color.green);

            if (canHover == true)
            {
                // Debug.Log("canHover is true");
                if (hoverHit.collider.tag == "MatchBox") //|| hoverHit.collider.tag == "Battery")
                {
                    Debug.Log("I'm looking at matchbox");
                    _HandImage.SetActive(true);
                    _CrossHairImage.SetActive(false);
                }
            }
            else
            {
             //   Debug.Log("Not looking at anything");
            }
             //   else if (hoverHit.collider.tag != "MatchBox" || hoverHit.collider.tag != "Battery")
               // {
                 //   Debug.Log("not looking at anything");
                   // _HandImage.SetActive(false);
                   // _CrossHairImage.SetActive(true);
                //}
            
        }

        if (Input.GetButton("Fire1"))
        {
            if (Physics.Raycast(ray, out fireHit, range))
            {
                Debug.DrawRay(ray.direction, fireHit.point, Color.red);

                if (fireHit.collider.tag == "Matchbox")
                {
                    _Matchbox.AddMatch();
                }

                else if (fireHit.collider.tag == "Battery")
                {
                    _Battery.AddBatteries();
                }

                Debug.Log(fireHit.transform.name);
            }
        }
    }

}