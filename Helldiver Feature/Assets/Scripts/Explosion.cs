using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Cranford, Clayton]
 * Last Updated: [05/09/2024]
 * [File handles the destruction of the 500kg bomb's explosion]
 */

public class Explosion : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyExplosion());
    }

    /// <summary>
    /// Destroys the explosion after 7 seconds
    /// </summary>
    /// <returns></returns>
    private IEnumerator DestroyExplosion()
    {
        yield return new WaitForSeconds(7);
        Destroy(explosion.gameObject);
    }
}
