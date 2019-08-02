using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Select : MonoBehaviour
{

    [HideInInspector]
    public GameObject mainCamera;

    [HideInInspector]
    public bool mainCameraSelected;

    [HideInInspector]
    public GameObject marker;

    private bool canChangeCam = true;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        marker = GameObject.Find("Marker");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && canChangeCam && marker.GetComponent<Mk_Follow>().entity.transform.childCount > 0)
        {
            if (mainCameraSelected)
            {
                mainCamera.SetActive(false);
                if (marker.GetComponent<Mk_Follow>().entity.transform.childCount > 0)
                {
                    marker.GetComponent<Mk_Follow>().entity.transform.GetChild(0).gameObject.SetActive(true);
                }
                mainCameraSelected = false;
            } else
            {
                if (marker.GetComponent<Mk_Follow>().entity.transform.childCount > 0)
                {
                    marker.GetComponent<Mk_Follow>().entity.transform.GetChild(0).gameObject.SetActive(false);
                }
                mainCamera.SetActive(true);
                mainCameraSelected = true;
            }
            canChangeCam = false;
            StartCoroutine(AntiCamSpam());
        }
        if (marker.GetComponent<Mk_Follow>().entity==null)
        {
            mainCamera.SetActive(true);
            mainCameraSelected = true;
        }
    }

    IEnumerator AntiCamSpam()
    {
        yield return new WaitForSeconds(0.1f);
        canChangeCam = true;
    }

}
