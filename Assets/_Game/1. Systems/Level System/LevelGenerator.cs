using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Items List")]
    public List<GameObject> objectsToSpwan;
    [Header("Level Generation Params")]
    [Tooltip("How many chunks you want in this level")]
    public int levelLength;
    public GameObject first;
    public GameObject end;
    public List<GameObject> chunks = new List<GameObject>();
    public GameObject levelParent;
    public Transform poser;

    private Turn previousTurn = Turn.NULL;
    private Turn previousChunk = Turn.NULL;
    [HideInInspector] public Vector3 endPosition;
    private void Start()
    {
        GenerateLevel();
    }
    public LevelGenerator GenerateLevel()
    {
        if (levelParent.transform.childCount > 0)
        {
            levelParent.transform.DestroyChildren();
            poser.transform.position = Vector3.zero;
            poser.transform.eulerAngles = new Vector3(0, 270, 0); //this line is important and shouldn't be changed
        }
        //spawn first zero
        GameObject zero = Instantiate(first, levelParent.transform);
        zero.transform.position = poser.position;
        zero.transform.eulerAngles = poser.eulerAngles;
        poser = zero.GetComponent<Chunk>().end;

        //spawn Array
        for (int i = 0; i < levelLength; i++)
        {
            int x = Random.Range(0, chunks.Count);
            //turn verification
            if (chunks[x].GetComponent<Chunk>().thisTurn != Turn.NULL)
            {
                if (previousTurn != chunks[x].GetComponent<Chunk>().thisTurn &&
                    previousChunk != Turn.RIGHT && previousChunk != Turn.LEFT)
                {

                    previousTurn = chunks[x].GetComponent<Chunk>().thisTurn;
                }
                else
                {
                    i--;
                    continue;
                }
            }
            if (i == 2 && chunks[x].GetComponent<Chunk>().thisTurn == Turn.NULL)
            {
                var item = Instantiate(objectsToSpwan[0], levelParent.transform);
                item.transform.position = poser.position;
                item.transform.eulerAngles = poser.eulerAngles;
            }
            if (i == 3 && chunks[x].GetComponent<Chunk>().thisTurn == Turn.NULL)
            {
                var item = Instantiate(objectsToSpwan[1], levelParent.transform);
                item.transform.position = poser.position;
                item.transform.eulerAngles = poser.eulerAngles;
            }
            GameObject inst = Instantiate(chunks[x], levelParent.transform);
            inst.transform.position = poser.position;
            inst.transform.eulerAngles = poser.eulerAngles;
            poser = inst.GetComponent<Chunk>().end;
            previousChunk = inst.GetComponent<Chunk>().thisTurn;
        }
        //spawn end level
        GameObject last = Instantiate(end, levelParent.transform);
        last.transform.position = poser.position;
        last.transform.eulerAngles = poser.eulerAngles;
        endPosition = last.transform.position;
        return this;
    }
    private void InGameItems()
    {

    }
    public void ButtonCall()
    {
        GenerateLevel();
    }
}
