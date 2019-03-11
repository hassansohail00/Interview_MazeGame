using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ObjectDestory", 0.4f);
    }
    void ObjectDestory() {
        Destroy(transform.parent.gameObject);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
