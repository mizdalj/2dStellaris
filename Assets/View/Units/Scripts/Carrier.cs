using UnityEngine;
public class Carrier : Ship
{
    public int Capacity;

    public override void MoveTo(Vector2 newPosition)
    {
        // Implement carrier-specific movement logic here,
        // For example, taking Capacity into account
    }

    // Any other carrier-specific methods go here
}