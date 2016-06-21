using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject spawn;
    public GameObject blob;

    //public bool collided = false;
    blobscript b;



	// Use this for initialization
	void Start () {
        b = GameObject.Find("Blob(Clone)").GetComponent<blobscript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(spawn, transform.position, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(blob, transform.position, Quaternion.identity);
            b.gameObject.layer = 8;
            
            //collided = false;
            //GameObject.FindGameObjectsWithTag("ball").Equals("Blob(Clone)");
            //collisions = 0;
        }
    }
    }
