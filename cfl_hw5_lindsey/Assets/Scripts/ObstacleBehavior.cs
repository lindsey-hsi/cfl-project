using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    private int obstacleHealth = 25;
    public float onscreenDelay = 3f;
    // public BlastBehavior blst;
    public Transform marble;
    

    public int Health {
      get {return obstacleHealth; }

      private set {
        obstacleHealth = value;

        if (obstacleHealth <= 0) {
          Destroy(this.gameObject);
          Debug.Log("obstacle removed");
        }
        Debug.LogFormat("Obstacle Health: {0}", obstacleHealth);
      }
    }
    // void OnTriggerEnter(Collider collider) {
    //   if (collider.name == "Blast") {
    //     Debug.Log("hit by blast!");
    //     obstacleHealth -= 10;
    //     if (obstacleHealth < 0) {
    //       Destroy(this.gameObject, onscreenDelay);
    //     }
    //   }
    // }
    // Start is called before the first frame update
    void Start()
    {
      // blst = GameObject.Find("Blast(Clone)").GetComponent<BlastBehavior>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision) {
      // if (collision.gameObject.tag == "Blast") {
      // works if marble collides, something with the name of blast, but not sure what
      // if (collision.gameObject.name == "Marble") {
      // collisions are definitely detected with the blasts (as seen with the debug message above)
      if (collision.gameObject.name == "Blast(Clone)") {
        Debug.Log("blast detected!");
        Health -= 5;
        Debug.Log("hit by blast!");

      }
    }
}
