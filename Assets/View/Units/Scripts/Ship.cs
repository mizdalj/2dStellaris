using UnityEngine;
public abstract class Ship : MonoBehaviour
{
    public float Speed;
    public float Health;
    public Vector2 Position;

    public virtual void MoveTo(Vector2 newPosition)
    {
        // Implement basic movement logic here
    }

    public virtual void TakeDamage(float damage)
    {
        Health -= damage;
        // Implement any additional damage logic here
    }

    // Any other common ship methods go here
}