using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject bomb;
    public GameObject laser;
    public GameObject gas;
    public GameObject turret;
    public GameObject ball;
    public float ground;
    private Vector3 bombSpawn;
    private Vector3 laserSpawn;
    private Vector3 turretSpawn;
    // Update is called once per frame
    void Update()
    {
        if(ball.transform.position.y <= ground)
        {
            SpawnStrat();
        }
    }

    private void SpawnStrat()
    {
        if(ball.GetComponent<PlayerControl>().bomb == true)
        {
            bombSpawn = new Vector3(transform.position.x, transform.position.y + 50, transform.position.z + 30);
            Instantiate(bomb, bombSpawn, Quaternion.identity);
        }
        else if (ball.GetComponent<PlayerControl>().laser == true)
        {
            laserSpawn = new Vector3(transform.position.x - 7, transform.position.y + 48, transform.position.z);
            Instantiate(laser, laserSpawn, Quaternion.identity);
        }
        else if (ball.GetComponent<PlayerControl>().gas == true)
        {
            Instantiate(gas, transform.position, Quaternion.identity);
        }
        else if (ball.GetComponent<PlayerControl>().turret == true)
        {
            turretSpawn = new Vector3(transform.position.x, transform.position.y + 50, transform.position.z);
            Instantiate(turret, turretSpawn, Quaternion.identity);
        }

    }
}
