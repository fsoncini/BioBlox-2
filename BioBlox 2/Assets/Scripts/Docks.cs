using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Docks : MonoBehaviour {

    public List<GameObject> docks;

    void Update ()
    {
        CountChildren();
    }


    void CountChildren ()
    {
        foreach (Transform child in transform)
        {
            Debug.Log("Foreach loop: " + child);
            docks.Add(child.gameObject);
        }

        //{
        //    int children = transform.childCount;
        //    for (int i = 0; i < children; ++i)
        //    {
        //        Debug.Log("For loop: " + transform.GetChild(i));
        //        docks.Add(GameObject.Find("Docks").);
        //    }

        //}

    }

}
