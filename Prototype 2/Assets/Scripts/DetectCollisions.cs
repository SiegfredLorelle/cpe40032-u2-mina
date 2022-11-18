using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        // Destroy both food and animal on collision
        if (other.gameObject.name != "Player")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

        // Announce when a non-food (an animal) collided to player
        if (gameObject.name != "Food_Steak_01(Clone)" && gameObject.name != "Food_Bone_01(Clone)" && other.gameObject.name == "Player")
        {
            Debug.Log("You got hit by an dog!");
            Destroy(gameObject);
        }
    }
}
