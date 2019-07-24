using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouse_Hover : MonoBehaviour
{

    public Text Text_Food;
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
        } else
        {
            Text_Food.text = "0";
        }
        
    }
}
