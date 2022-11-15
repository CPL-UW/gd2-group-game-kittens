using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingChest : MonoBehaviour
{
    public GameObject obj;
    public GameObject screenBlast;
    public GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -2) {
            Instantiate(screenBlast, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            Destroy(obj);
            GM.SpawnCarrots();
            GM.SparkleScreen();
        }
    }
}
