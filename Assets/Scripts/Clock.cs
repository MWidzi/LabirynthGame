using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickUp
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool AddTime;

    public uint time = 5;

    public override void Picked()
    {
        Debug.Log("Clock");
        int sign = 1;
        if (!AddTime) sign = -1;

        GameManager.gameManager.AddTime((int)time * sign);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
