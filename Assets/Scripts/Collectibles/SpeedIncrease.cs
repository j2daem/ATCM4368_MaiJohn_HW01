using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncrease : CollectibleBase
{
    [SerializeField] float _speedAmount = 5f;

    protected override void Collect(Player player)
    {
        // Pull motor controller from the player
        TankController controller = player.GetComponent<TankController>();
        if (controller != null)
        {
            controller.MaxSpeed += _speedAmount;
        }
    }

    protected override void Movement(Rigidbody rb)
    {
        // Calculate rotation
        Quaternion turnOffset = Quaternion.Euler(MovementSpeed, MovementSpeed, MovementSpeed);
        rb.MoveRotation(rb.rotation * turnOffset);
    }
}
