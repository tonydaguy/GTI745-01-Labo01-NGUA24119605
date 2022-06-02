using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Singleton instance of this spawner class
    public static Spawner Instance { get; private set; }

    // References to planes prefab
    public GameObject redPlane;

    // Turret position
    private Vector3 turretPosition;

    // Create the singleton instance before starting the app
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public void setTurretPosition(Vector3 p_turretPosition)
    {
        turretPosition = p_turretPosition;
    }
    public void spawnPlane(GameObject plane)
    {
        // Create an empty gameobject to work with transform
        GameObject planeSpawnPoint = new GameObject();

        // Random height to add from the turret position
        float extraHeight = Random.Range(0.5f, 1.5f);

        // Random depth to add from the turret position
        float extraDepth = Random.Range(0.5f, 1.5f);

        // Create the spawn position
        Vector3 planeSpawnPosition = new Vector3(0.0f, this.turretPosition.y + extraHeight, this.turretPosition.z + extraDepth);

        // Set the position of the spawn
        planeSpawnPoint.transform.position = planeSpawnPosition;

        // Instance the plane at the spawn position
        Instantiate(plane, planeSpawnPoint.transform);
    }

    public void spawnRedPlane()
    {
        spawnPlane(redPlane);
    }
}
