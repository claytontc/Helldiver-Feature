using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: [Cranford, Clayton]
 * Last Updated: [05/09/2024]
 * [File handles the spawning of the strategems]
 */

public class Ball : MonoBehaviour
{
    public GameObject bomb;
    public GameObject laser;
    public GameObject gas;
    public GameObject turret;
    public GameObject ball;
    public GameObject player;
    public float ground;
    private Vector3 bombSpawn;
    private Vector3 laserSpawn;
    private Vector3 turretSpawn;
    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Debug.Log("ball hit ground");
            SpawnStrat();
        }
    }


    /// <summary>
    /// Spawns a strategem depending on which sequence was correctly entered
    /// </summary>
    private void SpawnStrat()
    {
        if(player.GetComponent<PlayerControl>().bomb)
        {
            Debug.Log("Liberty is on its way");
            bombSpawn = new Vector3(ball.transform.position.x, ball.transform.position.y + 50, ball.transform.position.z + 30);
            Instantiate(bomb, bombSpawn, Quaternion.identity);
            ball.GetComponent<PlayerControl>().bomb = false;
            player.GetComponent<PlayerControl>().bomb = false;
        }
        else if (player.GetComponent<PlayerControl>().laser == true)
        {
            laserSpawn = new Vector3(ball.transform.position.x - 7, ball.transform.position.y + 48, ball.transform.position.z);
            Instantiate(laser, laserSpawn, Quaternion.identity);
            ball.GetComponent<PlayerControl>().laser = false;
            player.GetComponent<PlayerControl>().laser = false;
        }
        else if (player.GetComponent<PlayerControl>().gas == true)
        {
            Instantiate(gas, ball.transform.position, Quaternion.identity);
            ball.GetComponent<PlayerControl>().gas = false;
            player.GetComponent<PlayerControl>().gas = false;
        }
        else if (player.GetComponent<PlayerControl>().turret == true)
        {
            turretSpawn = new Vector3(ball.transform.position.x, ball.transform.position.y + 50, ball.transform.position.z);
            Instantiate(turret, turretSpawn, Quaternion.identity);
            ball.GetComponent<PlayerControl>().turret = false;
            player.GetComponent<PlayerControl>().turret = false;
        }

    }
}
