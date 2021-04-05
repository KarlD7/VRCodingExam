using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehavior : MonoBehaviour
{
    public void changeObject()
    {
        GameObject donut = GameObject.Find("Donut_02");
        GameObject curr = this.gameObject;
        Instantiate(donut, this.transform.position, this.transform.rotation);
        Destroy(curr);
    }
}