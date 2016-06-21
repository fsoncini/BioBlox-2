using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Docks : MonoBehaviour {

    public List<GameObject> docks;


   public void CountChildren ()
    {
        foreach (Transform child in transform)
        {
            Debug.Log("Foreach loop: " + child);
            docks.Add(child.gameObject);
        }

    }

}
