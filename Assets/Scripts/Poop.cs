using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{
    [SerializeField] private GameObject particle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     Debug.Log("on Collision");
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            GameManager.instance.AddScore();
        }
        else if (other.gameObject.tag == "Player")
        {
            GameManager.instance.SetGameOver();
            Player player = other.gameObject.GetComponent<Player>();
            player.GetPooped();
        }
        else if (other.gameObject.tag == "Poop")
        {
            return;
        }

        Instantiate(particle, transform.position, Quaternion.identity);
        GetComponent<AudioSource>().Play();
        GetComponent<Renderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject, 1f);
    }
}
