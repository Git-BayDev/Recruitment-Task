using UnityEngine;

public class ChestSpawn : MonoBehaviour
{
    public GameObject chest;
    void Awake()
    {
        spawnChest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void spawnChest() 
    {
        float xSize = Random.Range(-8.0f,26.0f);
        float zSize = Random.Range(-3.0f,27.0f);
        Vector3 spawnPos = new Vector3(xSize,0.2f,zSize);
        Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(0, 360), 0f);
        transform.position = spawnPos;
        Instantiate(chest,transform.position,randomRotation);
    }
}
