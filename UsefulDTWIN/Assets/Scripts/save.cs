using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save : MonoBehaviour
{


    public struct NodeSaveData
    {
        public int uid;
        public Vector3 vector;
    }


    // Start is called before the first frame update
    void Start()
    {

        NodeSaveData nodeSaveData;
        List<NodeSaveData> listNodeSaveData = new List<NodeSaveData>();

        Vector3[] intermediate_vector;

        List<Vector3> listVector3 = new List<Vector3>();

        Vector3[] loadVector3;

        //Vector3 vec1 = new Vector3(0, 1, 1);

        listVector3.Add(new Vector3(0, 1, 1));
        listVector3.Add(new Vector3(0, 1, 2));

        intermediate_vector = listVector3.ToArray();


        List<string> intermediate_string = new List<string>();

        List<string> loadString = new List<string>();

        SaveManager.SaveMoney(100);

        intermediate_string.Add("aa");
        intermediate_string.Add("bb");


        nodeSaveData = new NodeSaveData
        {
            uid = 1,
            vector = new Vector3(0, 0, 0)
        };


        listNodeSaveData.Add(nodeSaveData);


        nodeSaveData.uid = 2;
        nodeSaveData.vector = new Vector3(0, 0, 0);
        listNodeSaveData.Add(nodeSaveData);

        SaveManager.SaveDeck(intermediate_string);


        SaveManager.SaveVector(intermediate_vector);

        loadString= SaveManager.saveData.deck;
        loadVector3 = SaveManager.saveData.vector;


        Debug.Log(loadVector3);

        foreach (Vector3 load in loadVector3)
        {
            Debug.Log(load);

        }






    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
