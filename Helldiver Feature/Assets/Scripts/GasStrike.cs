using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasStrike : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyGas());
    }

    private IEnumerator DestroyGas()
    {
        yield return new WaitForSeconds(15);
        Destroy(this.gameObject);
    }
}
