using UnityEngine;

public class ChestSpawn : MonoBehaviour
{
    public GameObject chest;
    void Start()
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
        transform.position = spawnPos;
        Instantiate(chest,transform.position,transform.rotation);
    }
}
