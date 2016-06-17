using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject spawn;
    public GameObject blob;

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
            Instantiate(blob, transform.position, Quaternion.identity);
        }
    }
    }
