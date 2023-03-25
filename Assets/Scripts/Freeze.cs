using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : PickUp
{
    public int FreezeTime = 10;

    public override void Picked()
    {
        GameManager.gameManager.FreezeTime(FreezeTime);
        Debug.Log("FreezeTime");
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
}
