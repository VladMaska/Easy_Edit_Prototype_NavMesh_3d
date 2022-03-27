using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour {

    public Vector3 pos;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    float time = 5;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    void Update(){

        transform.position = Vector3.MoveTowards( transform.position, pos, 0.1f );

        Destroy( this.gameObject, time );

    }

    private void OnCollisionEnter( Collision collision ){

        GameObject obj = collision.gameObject;

        if ( obj.tag == "Enemy")
            Destroy( this.gameObject );

    }

    private void OnTriggerEnter( Collider other ){

        GameObject obj = other.gameObject;

        if ( obj.tag == "Enemy")
            Destroy( this.gameObject );
        
    }

}