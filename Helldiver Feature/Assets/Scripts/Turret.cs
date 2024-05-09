using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject ball;
    public GameObject turret;
    public float ground;
    public float speed = 50f;
    private Vector3 landingPoint;
    private List<int> inputSequence = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        landingPoint = new Vector3(ball.transform.position.x, ground, ball.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (turret.transform.position.y > ground)
        {
            turret.transform.position = Vector3.MoveTowards(turret.transform.position, ball.transform.position, speed);
        }
        else
        {
            turret.transform.position = landingPoint;
        }
    }
}
