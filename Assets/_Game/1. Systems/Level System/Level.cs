using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this level generator will simply allign the level chunks provided in list
public class Level : MonoBehaviour
{
    public GameObject first;
    public GameObject end;

    [SerializeField] private List<GameObject> chunks = new List<GameObject>();
    [HideInInspector] public Vector3 endPosition;
    [HideInInspector] public List<Chunk> allChunks = new List<Chunk>();

    public Level GenerateLevel(Transform poser)
    {
        if (transform.childCount > 0)
        {
            transform.DestroyChildren();
            poser.transform.position = Vector3.zero;
            poser.transform.eulerAngles = new Vector3(0, 270, 0); //this line is important and shouldn't be changed
        }
        //spawn first zero
        GameObject zero = Instantiate(first, transform);
        zero.transform.position = poser.position;
        zero.transform.eulerAngles = poser.eulerAngles;
        poser = zero.GetComponent<Chunk>().end;
        allChunks.Add(zero.GetComponent<Chunk>());
        //spawn Array
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject inst = Instantiate(chunks[i], transform);
            inst.transform.position = poser.position;
            inst.transform.eulerAngles = poser.eulerAngles;
            poser = inst.GetComponent<Chunk>().end;
            allChunks.Add(inst.GetComponent<Chunk>());
        }
        //spawn end level
        GameObject last = Instantiate(end, transform);
        last.transform.position = poser.position;
        last.transform.eulerAngles = poser.eulerAngles;
        endPosition = last.transform.position;
        allChunks.Add(last.GetComponent<Chunk>());

        return this;
    }



    private void ItemsToSpawn()
    {
        //if (i == 2 && chunks[x].GetComponent<Chunk>().thisTurn == Chunk.Turn.NULL)
        //{
        //    var item = Instantiate(objectsToSpwan[0], levelParent.transform);
        //    item.transform.position = poser.position;
        //    item.transform.eulerAngles = poser.eulerAngles;
        //}
        //if (i == 3 && chunks[x].GetComponent<Chunk>().thisTurn == Chunk.Turn.NULL)
        //{
        //    var item = Instantiate(objectsToSpwan[1], levelParent.transform);
        //    item.transform.position = poser.position;
        //    item.transform.eulerAngles = poser.eulerAngles;
        //}
    }

}
