using UnityEngine;

public class Oar : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float torque;
    [SerializeField] private float interval;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private SpriteRenderer renderer;

    private float lastRow;

    public void Row()
    {
        if (Time.time - lastRow >= interval)
        {
            body.AddRelativeForce(Vector2.up * force);
            body.AddTorque(torque);
            renderer.flipY = !renderer.flipY;
            lastRow = Time.time;
        }
    }
}