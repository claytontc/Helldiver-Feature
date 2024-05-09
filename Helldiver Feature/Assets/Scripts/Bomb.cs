using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

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
        landingPoint = new Vector3(bomb.transform.position.x, ground, bomb.transform.position.z);
        ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if(bomb.transform.position.y > ground)
        {
            bomb.transform.position = Vector3.MoveTowards(bomb.transform.position, ball.transform.position, speed);
        }
        else
        {
            bomb.transform.position = landingPoint;
            StartCoroutine(TickTickBoom());
        }
    }

    private IEnumerator TickTickBoom()
    {
        yield return new WaitForSeconds(1);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    private IEnumerator DestroyExplosion()
    {
        yield return new WaitForSeconds(7);
        Destroy(explosion.gameObject);
    }
}
