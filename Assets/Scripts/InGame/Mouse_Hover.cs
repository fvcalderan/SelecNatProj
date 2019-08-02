using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Mouse_Hover : MonoBehaviour
{


    private Text Text_Food;
    private Text Text_Partner;
    private Text Text_Food_Range;
    private Text Text_Partner_Range;
    private Text Text_Wander_Time;
    private Text Text_Wander_Range;
    private Text Text_Speed;

    private GameObject Marker;
    private GameObject CameraController;

    private GameObject lastHit = null;

    private Collider[] colliders;

    // Start is called before the first frame update
    void Start()
    {
        Text_Food = GameObject.Find("Text_Food").GetComponent<Text>();
        Text_Partner = GameObject.Find("Text_Partner").GetComponent<Text>();
        Text_Food_Range = GameObject.Find("Text_Food_Range").GetComponent<Text>();
        Text_Partner_Range = GameObject.Find("Text_Partner_Range").GetComponent<Text>();
        Text_Wander_Time = GameObject.Find("Text_Wander_Time").GetComponent<Text>();
        Text_Wander_Range = GameObject.Find("Text_Wander_Range").GetComponent<Text>();
        Text_Speed = GameObject.Find("Text_Speed").GetComponent<Text>();

        Marker = GameObject.Find("Marker");
        CameraController = GameObject.Find("CameraSelector");
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

                colliders = Physics.OverlapSphere(hit.point, 1.5f);

                GameObject closest = null;
                float distance = Mathf.Infinity;

                foreach (Collider co in colliders)
                {
                    if (co.gameObject.tag == "Entity")
                    {
                        Vector3 diff = co.gameObject.transform.position - hit.point;
                        float curDistance = diff.sqrMagnitude;
                        if (curDistance < distance)
                        {
                            closest = co.gameObject;
                            distance = curDistance;
                        }
                    }
                }
                if (closest != null)
                {
                    lastHit = closest.gameObject;
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
            Text_Speed.text = lastHit.GetComponent<NavMeshAgent>().speed.ToString();
        } else
        {
            Text_Food.text = "0";
            Text_Partner.text = "0";
            Text_Food_Range.text = "0";
            Text_Partner_Range.text = "0";
            Text_Wander_Time.text = "0";
            Text_Wander_Range.text = "0";
            Text_Speed.text = "0";
        }
        
    }
}
