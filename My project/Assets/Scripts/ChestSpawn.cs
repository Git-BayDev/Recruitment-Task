using UnityEngine;

public class ChestSpawn : MonoBehaviour
{
    public GameObject chest;
    public GameObject door;
    void Awake()
    {
        spawn(chest);
        spawn(door);
    }


    public void spawn(GameObject spawnObject) 
    {
        float xSize = Random.Range(-8.0f,26.0f);
        float zSize = Random.Range(-3.0f,27.0f);
        Vector3 spawnPos = new Vector3(xSize,0.2f,zSize);
        Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(0, 360), 0f);
        transform.position = spawnPos;
        Instantiate(spawnObject,transform.position,randomRotation);
    }
}
