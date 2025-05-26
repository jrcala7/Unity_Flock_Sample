using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class EntityHandler : MonoBehaviour
{
    public EntityHandler Leader;
    public GameHandler handler;
    public List<EntityHandler> Neighbors = new List<EntityHandler>();

    public float SeparationDistance = 2.0f;
    public float MaxVelocity = 3.0f;
    public Vector3 velocity;

    public Vector3 AveragePosition = Vector3.zero;
    public Vector3 AverageVelocity = Vector3.zero;
    public Vector3 AverageSeparation = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Neighbors.Clear();
    }

    private void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }

    void FixedUpdate()
    {
        GetAverages();
    }

    private void GetAverages()
    {
        AveragePosition = Vector3.zero;
        AverageVelocity = Vector3.zero;
        AverageSeparation = Vector3.zero;

        velocity = Vector3.zero;
        int separation = 0;

        for (int i = 0; i < Neighbors.Count; i++)
        {
            AveragePosition += Neighbors[i].transform.position;
            AverageVelocity += Neighbors[i].velocity;

            Vector3 dist = transform.position - Neighbors[i].transform.position;

            if (dist.sqrMagnitude < SeparationDistance * SeparationDistance)
            {
                AverageSeparation += Neighbors[i].transform.position;
                separation++;
            }
        }

        if(Neighbors.Count > 0)
        {
            AveragePosition /= Neighbors.Count;
            AverageVelocity /= Neighbors.Count;
            if(separation > 0) 
                AverageSeparation /= separation;
        }

        AveragePosition = AveragePosition - transform.position;
        AverageSeparation = AverageSeparation - transform.position;

        if (Leader != null)
        {
            Vector3 LeaderDir = Leader.transform.position - transform.position;
            velocity += LeaderDir.normalized * handler.LeaderPrio;
        }

        velocity += AverageVelocity.normalized * handler.Alignment;
        velocity += AveragePosition.normalized * handler.Cohesion;
        velocity -= AverageSeparation.normalized * handler.Separation;

        velocity = Vector3.ClampMagnitude(velocity, MaxVelocity);

        if (!handler.Debug) return;

        Debug.DrawRay(transform.position,velocity, Color.yellow);
        Debug.DrawRay(transform.position, AveragePosition.normalized, Color.red);
        Debug.DrawRay(transform.position, AverageSeparation.normalized, Color.magenta);
    }

    public void AddNeighbor(EntityHandler handler)
    {
        //Avoid Adding self
        if (handler != this && 
            !Neighbors.Contains(handler))
        {
            Neighbors.Add(handler);
        }
    }

    public void RemoveNeighbor(EntityHandler handler)
    {
        //Avoid Removing Self
        if (handler != this && handler != Leader &&
            Neighbors.Contains(handler))
        {
            Neighbors.Remove(handler);
        }
    }
}
