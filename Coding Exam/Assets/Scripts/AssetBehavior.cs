using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AssetBehavior : MonoBehaviour
{
    public Transform patrolRoute;
    public List<Transform> locations;
    public Transform currLocation;

    void Start()
    {
        InitializePatrolRoute();
        MoveToNextLocation();
    }

    void Update()
    {
        if (this.transform.position == currLocation.position)
        {
            MoveToNextLocation();
        }
        else
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, currLocation.position, .01f);
        }

        if (XRInputManager.IsButtonDown() || Input.GetMouseButtonDown(0))
        {
            Ray ray = GameObject.Find("Player").transform.GetChild(0).GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.name == "Donut_01")
                {
                    SceneManager.LoadScene(1);
                }
            }
        }
    }

    void InitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }

    void MoveToNextLocation()
    {
        int lIndex = UnityEngine.Random.Range(0, 4);
        if (locations.Count == 0) return;
        currLocation = locations[lIndex];
        this.transform.position = Vector3.MoveTowards(this.transform.position, currLocation.position, .01f);
        //locationIndex = (locationIndex + 1) % locations.Count;
    }
}

