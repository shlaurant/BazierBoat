using UnityEngine;

namespace Water
{
    public class RemoveBody : MonoBehaviour
    {
        [SerializeField] private RiverSection section;

        private void OnTriggerExit2D(Collider2D col)
        {
            section.RemoveBody(col.attachedRigidbody);
        }
    }
}