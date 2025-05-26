using UnityEngine;

public class NeighborAreaHandler : MonoBehaviour
{
    public EntityHandler handler;

    private void OnTriggerEnter(Collider other)
    {
        EntityHandler entity = other.GetComponent<EntityHandler>();

        if (entity != null)
        {
            handler.AddNeighbor(entity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EntityHandler entity = other.GetComponent<EntityHandler>();

        if (entity != null)
        {
            handler.RemoveNeighbor(entity);
        }
    }
}
