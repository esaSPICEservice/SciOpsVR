using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;



public class HelloWorld : MonoBehaviour
{

    public string myName;

    [DllImport("CSpiceLib", CharSet = CharSet.Ansi)] private static extern void fibonacci_init(int a, int b);
    [DllImport("CSpiceLib", CharSet = CharSet.Ansi)]  private static extern bool fibonacci_next();
    [DllImport("CSpiceLib", CharSet = CharSet.Ansi)]  private static extern int fibonacci_index();
    [DllImport("CSpiceLib", CharSet = CharSet.Ansi)]  private static extern long fibonacci_current();
    [DllImport("CSpiceLib", CharSet = CharSet.Ansi)]  private static extern double GetPosition();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(myName + " I am alive!");
        Debug.Log("This is a C++ Function from the Dynamic Library");

        // Initialize a Fibonacci relation sequence.
        fibonacci_init(1, 1);
        // Write out the sequence values until overflow.
        Debug.Log(GetPosition());
    }

    // Update is called once per frame
    void Update()
    {

 //       {
//            do
//            {
//                Debug.Log(fibonacci_index() + ": "
//                    + fibonacci_current());
//            } while (fibonacci_next());
//            // Report count of values written before overflow.
//            Debug.Log(fibonacci_index() + 1 +
//                " Fibonacci sequence values fit in an " +
//                "unsigned 64-bit integer.");
//        }
    }
}

