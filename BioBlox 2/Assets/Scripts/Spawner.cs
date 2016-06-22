using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject spawn;
    public GameObject blob;

    blobscript b;



	// Use this for initialization
	void Start () {
        
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
            //creates clones Ball object
            Instantiate(blob, transform.position, Quaternion.identity);

            b = GameObject.Find("Blob(Clone)").GetComponent<blobscript>();
            b.gameObject.layer = 1;

    
        }
    }
    }
