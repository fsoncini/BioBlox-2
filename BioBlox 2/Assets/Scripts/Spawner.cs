using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject brick;
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
    }
