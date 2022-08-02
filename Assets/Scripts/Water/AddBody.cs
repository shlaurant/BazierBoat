using UnityEngine;

namespace Water
{
    public class AddBody : MonoBehaviour
    {
        [SerializeField] private RiverSection section;

        private void OnTriggerEnter2D(Collider2D col)
        {
            section.AddBody(col.attachedRigidbody);
        }
    }
}