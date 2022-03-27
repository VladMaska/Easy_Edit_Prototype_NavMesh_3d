using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using NaughtyAttributes;

public class PlayerShoot : MonoBehaviour {

    [ShowAssetPreview]
    public GameObject bullet;
    public GameObject shootPos;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    MainPlayer mp;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    void Start() => mp = this.gameObject.GetComponent<MainPlayer>();

    void Update(){

#if UNITY_EDITOR

        if ( Input.GetMouseButtonDown( 0 ) && mp.canShoot )
            Shoot();

#else

        if ( Input.GetTouch( 0 ).phase == TouchPhase.Ended && mp.canShoot )
            Shoot();

#endif

    }

    void Shoot(){

        Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
        RaycastHit hit;

        if ( Physics.Raycast( ray, out hit, Mathf.Infinity ) ){

            print( hit.point );

            GameObject b = Instantiate( bullet, shootPos.transform.position, Quaternion.identity, transform );
            b.name = "Bullet";

            Bullet bs = b.GetComponent<Bullet>();
            bs.pos = hit.point;

        }

    }

}