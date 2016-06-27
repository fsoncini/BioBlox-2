using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    Spawner _SpawnerManager;

	// Use this for initialization
	void Start ()
    {
        _SpawnerManager = GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawner>();
    }
	
	// Update is called once per frame
	void Update ()

    {
	


	}
}
