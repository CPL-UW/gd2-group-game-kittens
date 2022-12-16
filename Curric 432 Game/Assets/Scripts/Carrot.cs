using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
* Carrot Code
*/
public class Carrot : MonoBehaviour
{

    //Attributes
    bool canCollect = false;
    //Components
    private SpriteRenderer _carrotRenderer;
    public Rigidbody2D rb;

    //Other objects
    public GameObject shine; //Object to create when carrot is revealed
    private float _spawnpointY;
    private float _direction;

    void Start() {
        //By default, carrot sprite isn't rendered
        _carrotRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        _spawnpointY = transform.position.y;
        _direction = 1;
    }

    void Update() {
        carrotAnimation();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //When carrot collides with a pit, carrot can be collected and is rendered
        if(collision.gameObject.CompareTag("Pit")) {
            canCollect = true;
            _carrotRenderer.enabled = true;
            Instantiate(shine, new Vector3(rb.position.x, rb.position.y, 0), transform.rotation);
            Debug.Log("Carrot can be collected");
        }

        //When carrot collides with radar, carrot shines
        if(collision.gameObject.CompareTag("Radar")) {
            Debug.Log("Carrot is temporarily revealed");
            Instantiate(shine, new Vector3(rb.position.x, rb.position.y, 0), transform.rotation);
        }

        //When carrot collides with player and is able to be collected, it destroys itself
        if(collision.gameObject.CompareTag("Player") && canCollect) {
            Destroy(this.gameObject);
        }
        if(collision.gameObject.CompareTag("Player2") && canCollect) {
            Destroy(this.gameObject);
        }
    }

    //Shows location
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }

    void carrotAnimation() {
        transform.position = new Vector2(transform.position.x, transform.position.y + 0.005f*(_direction));
        if(transform.position.y >= _spawnpointY + 1) _direction*=-1;
        if(transform.position.y <= _spawnpointY) _direction*=-1;
    }
}
