using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject brick;
    public GameObject blob;
    public GameObject _springs;
    public GameObject _ProteinStruct;

    public GameObject[] ProteinStructArray = new GameObject[5];
    public GameObject[] springScriptArray = new GameObject[5]; //Maybe declare as gameobject??

    GameObject Ribosome;
    public int ChainLength, ChainLength2;

    public int[] ChainLengthArray = new int[5];

    public int numSpawnItems;
    public int numProteinStruct;

	// Use this for initialization
	void Start () {

        Ribosome = GameObject.FindGameObjectWithTag("Ribo");
        ChainLength = 1;
        ChainLength2 = 1;
        numProteinStruct = 0;

        for (int i = 0; i < 5; ++i)
        {
            ChainLengthArray[i] = 1;
        }

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

    public void Instantiator(int ProteinNumber) {

        if (ProteinStructArray[ProteinNumber] == null && springScriptArray[ProteinNumber] == null)
        {
            

            ProteinStructArray[ProteinNumber] = (GameObject)Instantiate(_ProteinStruct, transform.position, Quaternion.identity);
            ProteinStructArray[ProteinNumber].gameObject.tag = "struct" + (ProteinNumber+1);

            springScriptArray[ProteinNumber] = (GameObject)Instantiate(_springs, transform.position, Quaternion.identity); //Double Check this
            springScriptArray[ProteinNumber].gameObject.tag = "spring" + (ProteinNumber+1);

            numProteinStruct++;
        }
  
      }

    }
