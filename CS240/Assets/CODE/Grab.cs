using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour {

    SteamVR_Controller.Device controller;
    private LineRenderer lRender;
    Vector3[] positions;
    RaycastHit hit;

    //Reference to all the different kyles for the game
    public GameObject kyleGreen;
    public GameObject kyleBlue;
    public GameObject kyleRed;
    public GameObject kylePurple;
    //Controls which kyle animation is used when the specific kyle is popped from stack
    GameObject kyle;
    //Used so I can point at the locker and find its position
    public GameObject locker;
    //stack to make sure only the latest kyle animation is played on click.
    Stack<GameObject> kyles = new Stack<GameObject>();
    //Controls movement
    private Transform[] path = new Transform[2];
    private float speed = 1.0f;
    private float reachDist = 1.0f;
    private int currentPoint = 0;
    bool check = false;

    // Use this for initialization
    void Start ()
    {
        positions = new Vector3[2];
        SteamVR_TrackedObject trackedObj = GetComponent<SteamVR_TrackedObject>();
        controller = SteamVR_Controller.Input((int)trackedObj.index);
        lRender = GetComponent<LineRenderer>();
        path[0] = GameObject.FindGameObjectWithTag("Destination1").transform;
        path[1] = GameObject.FindGameObjectWithTag("Destination2").transform;              
    }
	
	// Update is called once per frame
	void Update ()
    {
        RaycastForKyles();

        if(check)
        {
            //Need to figure out which kyle to move

            Vector3 direction;
            direction = path[currentPoint].position - kyleRed.transform.position;

            kyleRed.transform.position += direction * Time.deltaTime * speed;

            if (direction.magnitude <= reachDist)
            {
                if (currentPoint < 2)
                    currentPoint++;
            }

            if (kyleRed.transform.position == GameObject.FindGameObjectWithTag("Destination2").transform.position)
            {
                check = false;
            }
        }
    }

    void RaycastForKyles()
    {
        Ray r = new Ray(transform.position, transform.forward);

        Debug.DrawRay(transform.position, transform.forward);

        //out finds out object it hit. Replace with Kyle.
        if(Physics.Raycast(r, out hit, Mathf.Infinity))
        {
            DisplayLine(true, hit.point);
        }
        else
        {
            DisplayLine(false, hit.point);
        }
    }

    void DisplayLine(bool IsKyleHit, Vector3 endpoint)
    {
        lRender.enabled = IsKyleHit;
        positions[0] = transform.position;
        positions[1] = endpoint;
        lRender.SetPositions(positions);
        
        //check to see if line is displayed and if button is pressed
        if(IsKyleHit && controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            //activate animation
            MoveKyle();
        }
    }

    void MoveKyle()
    {
        check = true;
    }
}
