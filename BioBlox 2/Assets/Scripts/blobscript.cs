using UnityEngine;
using System.Collections;

public class blobscript : MonoBehaviour {

    springs springScript;
    springs springScript2;

    blobscript OtherBlob;
    Spawner _Spawner;
    public bool collided;
    public bool NewStructCreated;
    GameObject thisItem;

    GameObject ProteinStruct, ProteinStruct2;
    ProteinStructData ProtStructData;

    springs[] SpringArray = new springs[5];


    void Start()
    {

        collided = false;
        NewStructCreated = false;
        thisItem = this.gameObject;
        springScript = GameObject.FindGameObjectWithTag("spring").GetComponent<springs>();
        springScript2 = GameObject.FindGameObjectWithTag("spring2").GetComponent<springs>();
        _Spawner = GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawner>();
        ProteinStruct = GameObject.FindGameObjectWithTag("Struct");
        ProteinStruct2 = GameObject.FindGameObjectWithTag("Struct2");

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            springScript.natural_length.Clear();
            springScript2.natural_length.Clear();

            springScript.balls.Clear();
            springScript2.balls.Clear();

            _Spawner.ChainLength = 1;
            _Spawner.ChainLength2 = 1;

            collided = false;

            Destroy(thisItem);
            _Spawner.numSpawnItems = 0;
        }
    }

    void OnMouseDrag()
    {
        // calculate the mouse position in world space.
        float camera_distance = 10;
        Vector2 mp = Input.mousePosition;
        Camera cam = GameObject.FindObjectOfType<Camera>();
        Vector3 mouse_pos = cam.ScreenToWorldPoint(new Vector3(mp.x, mp.y, camera_distance));
        Vector3 delta = mouse_pos - transform.position;

        // move the blob towards the mouse.
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
       // float spring_constant = 1;
       // rb.AddForce(new Vector2(delta.x * spring_constant, delta.y * spring_constant));

        transform.position = mouse_pos;
        //transform.rotation = Quaternion.identity; //Check this
    }

    void OnMouseDown()
    {

        
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButton(1) && thisItem.tag != "blob")
        {
            transform.Rotate(0, 0, 1);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        OtherBlob = coll.gameObject.GetComponent<blobscript>();

        if (coll.gameObject.name != "BottomWall" && coll.gameObject.name != "LeftWall" && coll.gameObject.name != "RightWall" && !collided && (coll.transform.parent == ProteinStruct.transform || _Spawner.ChainLength <= 2))
        {
            springScript.balls.Add(thisItem);
            _Spawner.ChainLength++;
            thisItem.transform.parent = ProteinStruct.transform;
            collided = true;

            //Calculate the relative distances between objects
            springScript.natural_length.Clear();

            for (int i = 0; i < springScript.balls.Count; ++i)
            {
                for (int j = i + 1; j < springScript.balls.Count; ++j)
                {
                    Rigidbody2D rb1 = springScript.balls[i].GetComponent<Rigidbody2D>();
                    Rigidbody2D rb2 = springScript.balls[j].GetComponent<Rigidbody2D>();
                    float d = (rb1.transform.position - rb2.transform.position).magnitude;
                    springScript.natural_length.Add(d);
                }
            }
        }

        else if (coll.gameObject.name != "BottomWall" && coll.gameObject.name != "LeftWall" && coll.gameObject.name != "RightWall" && !collided && (coll.transform.parent != ProteinStruct.transform))
        {
            

            if (!OtherBlob.collided && _Spawner.numProteinStruct < 5)

            {
                
                print("first Loop, Spawner");

                _Spawner.Instantiator(_Spawner.numProteinStruct);
               

                SpringArray[_Spawner.numProteinStruct - 1] = _Spawner.springScriptArray[_Spawner.numProteinStruct - 1].GetComponent<springs>();
                SpringArray[_Spawner.numProteinStruct - 1].balls.Add(thisItem);

                _Spawner.ChainLengthArray[_Spawner.numProteinStruct - 1]++;
                thisItem.transform.parent = _Spawner.ProteinStructArray[_Spawner.numProteinStruct - 1].transform;

                //Calculate the relative distances between objects
                SpringArray[_Spawner.numProteinStruct - 1].natural_length.Clear();

                for (int i = 0; i < SpringArray[_Spawner.numProteinStruct - 1].balls.Count; ++i)
                {
                    for (int j = i + 1; j < SpringArray[_Spawner.numProteinStruct - 1].balls.Count; ++j)
                    {
                        Rigidbody2D rb1 = SpringArray[_Spawner.numProteinStruct - 1].balls[i].GetComponent<Rigidbody2D>();
                        Rigidbody2D rb2 = SpringArray[_Spawner.numProteinStruct - 1].balls[j].GetComponent<Rigidbody2D>();
                        float d = (rb1.transform.position - rb2.transform.position).magnitude;
                        SpringArray[_Spawner.numProteinStruct - 1].natural_length.Add(d);
                    }
                }

                collided = true;
            }

            else if (OtherBlob.collided)
            {
                
                ProtStructData = OtherBlob.gameObject.GetComponentInParent<ProteinStructData>();

                print("Second Loop, Attacher, ProtStructID: " + ProtStructData.StructID);

                SpringArray[ProtStructData.StructID - 1] = _Spawner.springScriptArray[ProtStructData.StructID - 1].GetComponent<springs>();
                SpringArray[ProtStructData.StructID - 1].balls.Add(thisItem);

                _Spawner.ChainLengthArray[ProtStructData.StructID - 1]++;
                thisItem.transform.parent = _Spawner.ProteinStructArray[ProtStructData.StructID - 1].transform;

                //Calculate the relative distances between objects
                SpringArray[ProtStructData.StructID - 1].natural_length.Clear();

                for (int i = 0; i < SpringArray[ProtStructData.StructID - 1].balls.Count; ++i)
                {
                    for (int j = i + 1; j < SpringArray[ProtStructData.StructID - 1].balls.Count; ++j)
                    {
                        Rigidbody2D rb1 = SpringArray[ProtStructData.StructID - 1].balls[i].GetComponent<Rigidbody2D>();
                        Rigidbody2D rb2 = SpringArray[ProtStructData.StructID - 1].balls[j].GetComponent<Rigidbody2D>();
                        float d = (rb1.transform.position - rb2.transform.position).magnitude;
                        SpringArray[ProtStructData.StructID - 1].natural_length.Add(d);
                    }
                }

                collided = true;
            }
  
        }
    }
}