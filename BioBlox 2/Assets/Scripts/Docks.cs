using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Docks : MonoBehaviour {

    public List<GameObject> docks;
    public List<float> nl;

    public void CountChildren ()
    {
        //flush elements from list before reading
        docks.Clear();


        foreach (Transform child in transform)
        {
            Debug.Log("Foreach loop: " + child);
            docks.Add(child.gameObject);

            for (int i = 0; i < docks.Count; ++i)
            {
                for (int j = i + 1; j < docks.Count; ++j)
                {
                    Rigidbody2D rb1 = docks[i].GetComponent<Rigidbody2D>();
                    Rigidbody2D rb2 = docks[j].GetComponent<Rigidbody2D>();
                    float d = (rb1.transform.position - rb2.transform.position).magnitude;
                    nl.Add(d);
                }


            }

        }
 

    }

}
