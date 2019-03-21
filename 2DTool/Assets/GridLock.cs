using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridLock : MonoBehaviour
{
    public GameObject testingObject;
    public Vector3 objectCenter;

    public GameObject objecthitting;
    public GameObject objectHit;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        //objectCenter = testingObject.GetComponent<Renderer>().bounds.center;
        //Debug.Log(objectCenter);

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                
            }
        }
    }
    

}
