using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Object that entered trigger: {other}");
        RubyController controller = other.GetComponent<RubyController>();

        // Doing this test ensures that you are only giving health to Ruby, and not creating an error trying to do it on other objects.
        if (controller != null)
        {
            if(controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                Debug.Log($"health: {controller.health}");
                // gameObject is the Game Object that the script is attached to(collectible health pack)
                Destroy(gameObject);
            }
        }
    }
}
