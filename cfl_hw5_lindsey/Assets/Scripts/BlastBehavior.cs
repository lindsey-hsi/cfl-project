using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastBehavior : MonoBehaviour
{
    public float onscreenDelay = 3f;
    // public ObstacleBehavior obs;
    // Start is called before the first frame update
    // void Start()
    // {
    //     // obs = GameObject.Find("StationaryObstacles").GetComponent<ObstacleBehavior>();
    // }

    // void OnTriggerEnter(Collider collider) {
    //   if (collider.gameObject.name == "Obstacle") {
    //     Debug.Log("obstacle hit by blast!");
    //     obs.Health -= 10;
    //     if (obs.Health < 0) {
    //       Destroy(collider.gameObject);
    //     }
    //   }
    // }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, onscreenDelay);
    }
}
