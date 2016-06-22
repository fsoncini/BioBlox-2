using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject brick;
    public GameObject blob;
    public GameObject docks;

    private int dock_counter;
    blobscript b;
    Docks d;


	// Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(brick, transform.position, Quaternion.identity);
            b = GameObject.Find("Brick(Clone)").GetComponent<blobscript>();
            b.gameObject.layer = 2;

        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            //creates clones Ball object
            Instantiate(blob, transform.position, Quaternion.identity);

            b = GameObject.Find("Blob(Clone)").GetComponent<blobscript>();
            b.gameObject.layer = 1;

    
        }
  
    }

    public void CreateNewDocks ()
    {
        dock_counter++;
        Instantiate(docks, transform.position, Quaternion.identity);
        d = GameObject.Find("Docks").GetComponent<Docks>();
        
        //d.gameObject.tag = "d" + dock_counter;
    }

    }
