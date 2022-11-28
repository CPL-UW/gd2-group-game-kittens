using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    float startY;
    public GameObject obj;
    public GameObject blast;

    public Rigidbody2D rb;
    public Collider2D collision;

    [SerializeField] float minPower;
    [SerializeField] float maxPower;
    [SerializeField] bool aimLeft;
    float power; //Default is 7
    float direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        startY = rb.position.y;
        power = Random.Range(minPower, maxPower);
        if(aimLeft) {
            direction = -1;
        } else {
            direction = 1;
        }
        rb.AddForce(new Vector3(direction, 1, 0) * power, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(startY > rb.position.y && !(collision.gameObject.CompareTag("Pit"))) {
            Destroy(obj);
            Instantiate(blast, new Vector3(rb.position.x, rb.position.y, 0), transform.rotation);
            FindObjectOfType<AudioManager>().Play("Explosion");
            //Debug.Log("Blast");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(startY >= rb.position.y && collision.gameObject.CompareTag("Pit")) {
            Debug.Log("Defuse");
            Destroy(obj);
        }
    }
}
