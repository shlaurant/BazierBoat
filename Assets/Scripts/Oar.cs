using UnityEngine;

public class Oar : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float torque;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private SpriteRenderer renderer;

    public void Row()
    {
        body.AddRelativeForce(Vector2.up * force);
        body.AddTorque(torque);
        renderer.flipY = !renderer.flipY;
    }
}