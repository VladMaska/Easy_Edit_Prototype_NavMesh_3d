using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEditor.Animations;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using NaughtyAttributes;

public class MainPlayer : MonoBehaviour {

    [HorizontalLine]

    [Scene]
    public string scene;

    [ShowAssetPreview]
    public GameObject point;

    [HorizontalLine]

    public int needKill;
    public int killed = 0;

    [HorizontalLine]

    public Animator anim;
    public AnimatorController controller;

    [HorizontalLine]

    public bool canShoot;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    NavMeshAgent agent;
    Vector3 tp;
    Vector3 rot;

    int pN = 0;
    float dis;
    float[] points;

    public GameObject[] go_points;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    void Awake(){

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = true;
        agent.updateUpAxis = true;

        GetPoints();

    }

    void Update(){

        transform.position = new Vector3( transform.position.x, 0, transform.position.z );
        tp = transform.position;

        dis = Vector2.Distance( tp, point.transform.position );

        if ( dis > 0 ){

            canShoot = false;

            ChangeAnim( "Walk" );
            anim.Play( "Walking" );
            agent.SetDestination( point.transform.position );

        }
        else {

            if ( transform.eulerAngles != rot ){

                Quaternion quaternion = Quaternion.Euler( rot.x, rot.y, rot.z );
                transform.rotation= Quaternion.Slerp( transform.rotation, quaternion, .025f );

            }

            canShoot = true;

            ChangeAnim( "Shoot" );
            anim.Play( "StayShoot" );
            
        }

        Next();

        if ( Input.GetKeyDown( KeyCode.W ) )
            ChangeAnim( "Walk" );

        if ( Input.GetKeyDown( KeyCode.S ) )
            ChangeAnim( "Shoot" );
        
    }

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    void GetPoints(){

        go_points = GameObject.FindGameObjectsWithTag( "point" );
        points = new float[ go_points.Length ];

        for ( int i=0; i<go_points.Length; i++ )
            points[ i ] = float.Parse( go_points[ i ].name );

        Array.Sort( points );

        point = GetPoint();

    }

    GameObject GetPoint(){ return GameObject.Find( points[ pN ].ToString() ); }

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    void Next(){

        if ( killed == needKill ){

            killed = 0;

            if ( pN != points.Length - 1 )
                pN++;

            else
                SceneManager.LoadScene( scene );

            StartCoroutine( NextPoint() );

        }

    }

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    public void PlusKilled() => killed++;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    void ChangeAnim( string p_name ){

        AnimatorControllerParameter[] parameters = controller.parameters;

        for ( int i=0; i<parameters.Length; i++ ){

            if ( parameters[ i ].name == p_name )
                anim.SetBool( p_name, true );

            else
                anim.SetBool( parameters[ i ].name, false );

        }

    }

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    void OnTriggerEnter( Collider other ){

        GameObject obj = other.gameObject;

        if ( obj.tag == "point" ){

            rot = obj.GetComponent<Point>().rotation;
            needKill = obj.GetComponent<Point>().needKill;

        }
        
    }

    IEnumerator NextPoint(){

        yield return new WaitForSeconds( 1 );
        point = GetPoint();

    }

}