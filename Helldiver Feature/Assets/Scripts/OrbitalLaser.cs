using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Cranford, Clayton]
 * Last Updated: [05/09/2024]
 * [File handles the destruction of the orbital laser]
 */

public class OrbitalLaser : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyLaser());
    }

    /// <summary>
    /// Destroys the laser after 25 seconds
    /// </summary>
    /// <returns></returns>
    private IEnumerator DestroyLaser()
    {
        yield return new WaitForSeconds(25);
        Destroy(this.gameObject);
    }
}
