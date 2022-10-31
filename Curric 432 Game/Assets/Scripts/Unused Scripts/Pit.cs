using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Unused script
public class Pit : MonoBehaviour
{
    int lifeTime = 7;
    public void Start()
    {
        StartCoroutine(WaitThenDie());
    }
    IEnumerator WaitThenDie()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(this.gameObject);
    }
}
