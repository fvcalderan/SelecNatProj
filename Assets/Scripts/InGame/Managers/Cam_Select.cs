using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cam_Select : MonoBehaviour
{

    [HideInInspector]
    public GameObject mainCamera;

    [HideInInspector]
    public bool mainCameraSelected;

    [HideInInspector]
    public GameObject marker;

    private bool canChangeCam = true;

    private Button BTN_Cam;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        marker = GameObject.Find("Marker");
        BTN_Cam = GameObject.Find("BTN_Cam").GetComponent<Button>();

        BTN_Cam.onClick.AddListener(BTN_Cam_on_Click);
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

    void BTN_Cam_on_Click()
    {
        if (canChangeCam && marker.GetComponent<Mk_Follow>().entity.transform.childCount > 0)
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
        yield return new WaitForSeconds(1);
        canChangeCam = true;
    }

}
