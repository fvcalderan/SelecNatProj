using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{

    public Camera cam;
    public GameObject foodPrefab;

    private bool canPlaceFood = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && canPlaceFood == true)
            {
                Instantiate(foodPrefab, hit.point, Quaternion.identity);
                canPlaceFood = false;
                StartCoroutine(AntiFoodSpam());
            }
        }
    }

    IEnumerator AntiFoodSpam()
    {
        yield return new WaitForSeconds(1);
        canPlaceFood = true;
    }

}
