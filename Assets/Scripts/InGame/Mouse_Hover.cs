using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouse_Hover : MonoBehaviour
{

    public Text Text_Food;
    public Text Text_Partner;
    public Text Text_Food_Range;
    public Text Text_Partner_Range;
    public Text Text_Wander_Time;
    public Text Text_Wander_Range;
    public GameObject Marker;
    public GameObject CameraController;

    private GameObject lastHit = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraController.GetComponent<Cam_Select>().mainCameraSelected)
        {
            Ray ray;
            RaycastHit hit;

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Entity")
                {
                    lastHit = hit.collider.gameObject;
                    Marker.GetComponent<Mk_Follow>().entity = lastHit;
                }
            }
        }

        if (lastHit != null)
        {
            Text_Food.text = lastHit.GetComponent<Ett_Move>().food_qtty.ToString();
            Text_Partner.text = lastHit.GetComponent<Ett_Move>().partnerHunger.ToString();
            Text_Food_Range.text = lastHit.GetComponent<Ett_Move>().foodRange.ToString();
            Text_Partner_Range.text = lastHit.GetComponent<Ett_Move>().partnerRange.ToString();
            Text_Wander_Time.text = lastHit.GetComponent<Ett_Move>().wanderTimer.ToString();
            Text_Wander_Range.text = lastHit.GetComponent<Ett_Move>().wanderRadius.ToString();
        } else
        {
            Text_Food.text = "0";
            Text_Partner.text = "0";
            Text_Food_Range.text = "0";
            Text_Partner_Range.text = "0";
            Text_Wander_Time.text = "0";
            Text_Wander_Range.text = "0";
        }
        
    }
}
