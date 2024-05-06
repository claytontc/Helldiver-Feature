using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalLaser : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyLaser());
    }

    private IEnumerator DestroyLaser()
    {
        yield return new WaitForSeconds(25);
        Destroy(this.gameObject);
    }
}
