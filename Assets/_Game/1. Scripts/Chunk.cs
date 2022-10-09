using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chunk : MonoBehaviour
{
    public List<GameObject> gates;
    public enum Turn { NULL, LEFT, RIGHT }
    public Transform start;
    public Transform end;

    public Turn thisTurn;

    private void Start()
    {
        if (thisTurn != Turn.NULL)
        {
            gates[Random.Range(0, gates.Count)].SetActive(true);
        }
    }
}
