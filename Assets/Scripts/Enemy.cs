using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using NaughtyAttributes;

public class Enemy : MonoBehaviour {

    public int hp = 2;

    public Animator anim;
    public string playerName;
    public GameObject hp_bar;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    MainPlayer mp;
    int defaultHP;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    void Awake() => defaultHP = hp = 1;

    void Start(){

        mp = GameObject.Find( playerName ).GetComponent<MainPlayer>();

        hp_bar.GetComponent<Slider>().maxValue = defaultHP + 1;

    }

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    void Update(){

        if ( hp >= 0 )
            hp_bar.GetComponent<Slider>().value = hp + 1;

        else
            Destroy( hp_bar );

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