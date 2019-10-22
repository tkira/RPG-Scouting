using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{

    [SerializeField]
    private int sort = 5000;
    [SerializeField]
    private int offset = 0;
    private Renderer renderer;
    

    private void Awake()
    {
        renderer = gameObject.GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        renderer.sortingOrder = (int)(sort - transform.position.y - offset);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
