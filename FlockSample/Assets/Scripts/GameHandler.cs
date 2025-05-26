using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public EntityHandler Leader;
    public GameObject FlockObj;

    public int count = 100;
    public float variancePos = 10;

    public float LeaderPrio = 1f;
    public float Cohesion = 0.2f;
    public float Alignment = 0.1f;
    public float Separation = 0.1f;

    public bool Debug = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            SpawnObj();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObj()
    {
        GameObject f = Instantiate(FlockObj, this.transform);
        f.SetActive(true);
        EntityHandler flock = f.GetComponent<EntityHandler>();

        flock.Leader = Leader;
        flock.handler = this;
        Vector3 leaderPos = f.transform.position;

        f.transform.position = new Vector3(
                
                Random.Range(-variancePos, variancePos) + leaderPos.x,
                Random.Range(-variancePos, variancePos) + leaderPos.y,
                Random.Range(-variancePos, variancePos) + leaderPos.z

            );
    }
}
