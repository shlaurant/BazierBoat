using UnityEngine;

public class Oar : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private SpriteRenderer renderer;

    public void Row()
    {
        body.AddForce(transform.TransformVector(Vector2.up) * force);
        renderer.flipY = !renderer.flipY;
    }
}