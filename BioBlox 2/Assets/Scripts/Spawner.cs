using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject brick;
    public GameObject blob;
    public GameObject docks;
    //public GameObject springs;


    blobscript b;
    Docks d;
    //springs s;

	// Use this for initialization
	void Start () {
        Instantiate(docks, transform.position, Quaternion.identity);
        //Instantiate(springs, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(brick, transform.position, Quaternion.identity);
            
            //take out layers
            //b = GameObject.Find("Brick(Clone)").GetComponent<blobscript>();
            //b.gameObject.layer = 2;

        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            //creates clones of Ball object
            Instantiate(blob, transform.position, Quaternion.identity);

            //take out layers
            //b = GameObject.FindGameObjectWithTag("ball").GetComponent<blobscript>();
            //b.gameObject.layer = 1;
           // b.collided = false;
    
        }
  
    }

    public void CreateNewDocks ()
    {
       
        //Instantiate(springs, transform.position, Quaternion.identity);
        //s = GameObject.Find("springs(Clone)").GetComponent<springs>();

        Instantiate(docks, transform.position, Quaternion.identity);
        d = GameObject.FindWithTag("dock").GetComponent<Docks>();

        b.collided = false;

        //d.docks.Clear();
        //d.nl.Clear();

        //s.balls = d.docks_buffer;
        //s.natural_length = d.nl;


        //d = GameObject.Find("Docks(Clone)").GetComponent<Docks>();
        //d.gameObject.tag = "dock";
        //d.gameObject.tag = "d" + dock_counter;
    }

}
