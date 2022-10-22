using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public CharacterSO characterSO;
    public PathCreator path;
    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        Instance = this;

        Debug.Log(Application.persistentDataPath);
        DataManager.LoadData();
       
    }
    void Start()
    {
        DataManager.SaveData();
        path.bezierPath.AutoControlLength = 0.41f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
