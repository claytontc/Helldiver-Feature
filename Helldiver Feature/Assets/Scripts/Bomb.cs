using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

/*
 * Author: [Cranford, Clayton]
 * Last Updated: [05/09/2024]
 * [File handles the 500kg bomb's dropping, and exploding]
 */

public class Bomb : MonoBehaviour
{
    public GameObject ball;
    public GameObject bomb;
    public GameObject explosion;
    public float ground;
    public float speed = 50f;
    private Vector3 landingPoint;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball");
        landingPoint = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        landingPoint = ball.transform.position;
        if(bomb.transform.position.y > landingPoint.y)
        {
            bomb.transform.position = Vector3.MoveTowards(bomb.transform.position, landingPoint, speed);
        }
        else
        {
            bomb.transform.position = landingPoint;
            StartCoroutine(TickTickBoom());
        }
    }

    /// <summary>
    /// One second after landing, the bomb's explosion is spawned and the bomb itself is destroyed
    /// </summary>
    /// <returns></returns>
    private IEnumerator TickTickBoom()
    {
        yield return new WaitForSeconds(1);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }


}
