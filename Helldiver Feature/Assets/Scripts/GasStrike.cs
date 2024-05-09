using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Cranford, Clayton]
 * Last Updated: [05/09/2024]
 * [File handles the destruction of orbital gas strike's gas cloud]
 */

public class GasStrike : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyGas());
    }

    /// <summary>
    /// Destroys the gas cloud after 15 seconds.
    /// </summary>
    /// <returns></returns>
    private IEnumerator DestroyGas()
    {
        yield return new WaitForSeconds(15);
        Destroy(this.gameObject);
    }
}
