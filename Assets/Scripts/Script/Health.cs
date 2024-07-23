using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int h = 3;
    public int c ;
    public int d = 1 ;
   void Start()
    {
        c = h;
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "enemy")
        {
            c = c - d;
            print("Current health is" + c);
            if (c <= 0)
            {
                Destroy(col.gameObject);
            }
        }
    }

}