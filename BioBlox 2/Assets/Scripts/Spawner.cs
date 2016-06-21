using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject brick;
    public GameObject blob;
    GameObject Ribosome;

    public int numSpawnItems;

	// Use this for initialization
	void Start () {

        Ribosome = GameObject.FindGameObjectWithTag("Ribo");
        numSpawnItems = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(brick, Ribosome.transform.position, Quaternion.identity);
            numSpawnItems++;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(blob, Ribosome.transform.position, Quaternion.identity);
            numSpawnItems++;
        }
    }
    }
