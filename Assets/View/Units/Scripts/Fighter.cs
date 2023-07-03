using UnityEngine;
public class Fighter : Ship
{
    public float Maneuverability;

    public override void MoveTo(Vector2 newPosition)
    {
        // Implement fighter-specific movement logic here,
        // For example, taking Maneuverability into account
    }

    // Any other fighter-specific methods go here
}