using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<GameObject> chunks = new List<GameObject>();
    public GameObject levelParent;
    public Transform poser;
    public void GenerateLevel(List<GameObject> chunks)
    {

    }
    private void Start()
    {
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject inst = Instantiate(chunks[i], levelParent.transform);
            inst.transform.position = poser.position;
            inst.transform.eulerAngles = poser.eulerAngles;
            poser = inst.GetComponent<Chunk>().end;
            
            
        }
    }
}
