using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using NaughtyAttributes;

public class Point : MonoBehaviour {

    [ShowAssetPreview]
    public GameObject point;
    public Vector3 rotation;
    public int needKill;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    void Update() => point.SetActive( GameCore.showPoint );

}