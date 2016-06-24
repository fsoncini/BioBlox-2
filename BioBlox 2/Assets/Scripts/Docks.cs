using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Docks : MonoBehaviour
{

    public List<GameObject> docks;
    public List<GameObject> docks_buffer;
    public List<float> nl;


    private bool docks_limit;

    Spawner sp;

    public void CountChildren()
    {
        //flush elements from list before reading
        docks.Clear();
        nl.Clear();

        foreach (Transform child in transform)
        {
            //Debug.Log("Foreach loop: " + child);
            if (docks.Count < 3 && !docks_limit)

            {
                docks.Add(child.gameObject);
            }

            else

            {
                if (docks_buffer.Count < 3)
                {

                    docks_buffer.Add(child.gameObject);
                    //gameObject.tag = "Untagged";
                    docks_limit = true;
                    //CreateObjectBuffer();
                    //sp.CreateNewDocks();
                }
            }

            //else
            //{
            //    //docks.Clear();
            //    //nl.Clear();
            //    docks_limit = true;
            //    sp = GameObject.Find("Spawner").GetComponent<Spawner>();
            //    sp.CreateNewDocks();
            //    gameObject.tag = "Untagged";

            //}
        }


        //establishing relationship between one item and all the others
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

    void CreateObjectBuffer()
    {

        for (int i = 0; i < docks_buffer.Count; i++)
        {
            docks_buffer[i].tag = "new";

        }

    }






}