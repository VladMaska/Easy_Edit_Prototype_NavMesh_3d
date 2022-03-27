using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using NaughtyAttributes;

public class Enemy : MonoBehaviour {

    public int hp = 1;

    public Animator anim;
    public string playerName;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    MainPlayer mp;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    void Awake() => hp = 1;

    void Start() => mp = GameObject.Find( playerName ).GetComponent<MainPlayer>();

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    void Update(){


        
    }

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    private void OnCollisionEnter( Collision collision ){

        if ( collision.gameObject.name == "Bullet" )
            hp--;

        if ( collision.gameObject.name == "Bullet" && hp == -1 ){

            Destroy( this.gameObject.GetComponent<BoxCollider>() );
            Destroy( anim );

            mp.killed++;

        }
        
    }

}