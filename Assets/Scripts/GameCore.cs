using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
 
public class GameCore : MonoBehaviour {

    public static bool showPoint = true;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    void Update(){

        if ( Input.GetKeyDown( KeyCode.S ) )
            showPoint = !showPoint;
        
    }

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

}