using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionScript : MonoBehaviour
{
    [System.SerializableAttribute]
    public class ValueList
    {
        public List<GameObject> List = new List<GameObject>();

        public ValueList(List<GameObject> list)
        {
            List = list;
        }
    }

    [SerializeField]
    private List<ValueList> panel = new List<ValueList>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
