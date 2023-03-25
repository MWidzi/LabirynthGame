using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public virtual void Picked()
    {
        Debug.Log("Podniosłem");
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Rotation()
    {
        transform.Rotate(new Vector3(0, 0.2f , 0));
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
}
