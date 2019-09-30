using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


public class HelloWorld : MonoBehaviour
{

    public string myName;

    [DllImport("CSpiceLib", CharSet = CharSet.Ansi)]  private static extern void LoadMK();
    [DllImport("CSpiceLib", CharSet = CharSet.Ansi)]  private static extern float GetPosition(float et, int pos);

    private float et0 = 599572869.184f;
    private float et;
    private float waitTime = 2.0f;
    private float visualTime = 0.0f;
    private char utc;

    private Vector3 bodyPosition;
    private float xPosition, yPosition, zPosition;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(myName + " I am alive!");
        Debug.Log("This is a C++ Function from the Dynamic Library");
        LoadMK();
        et = et0;

    }


    // Update is called once per frame
    void Update()
    {

        et += Time.fixedDeltaTime*2000;
        visualTime += Time.fixedDeltaTime;

        xPosition = GetPosition(et, 1);
        yPosition = GetPosition(et, 2);
        zPosition = GetPosition(et, 3);

        // Move sphere around the circle.
        bodyPosition = new Vector3(xPosition, yPosition, zPosition);
        transform.position = bodyPosition;



        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.
        if (visualTime > waitTime)
        {
           // Debug.Log(et);
            Debug.Log(xPosition);
            //Debug.Log(ycoord);
            //Debug.Log(zcoord);
            // Remove the recorded 2 seconds.
            visualTime = 0.0f;

        }
    }


    


}

