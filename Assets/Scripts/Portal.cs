using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Camera myCamera;
    public GameObject player;
    public Transform myRenderPlane;
    public Transform myColliderPlane;
    public Portal otherPortal;

    PortalCamera portalCamera;
    PortalTeleport portalTeleport;
    public Material material;

    float myAngle;

    private void Awake()
    {
        portalCamera = myCamera.GetComponent<PortalCamera>();
        portalTeleport = myColliderPlane.GetComponent<PortalTeleport>();
        player = GameObject.FindGameObjectWithTag("Player");

        portalCamera.playerCamera = player.gameObject.transform.GetChild(0);
        portalCamera.otherPortal = otherPortal.transform;
        portalCamera.portal = this.transform;

        portalTeleport.Player = player.transform;
        portalTeleport.Reciever = otherPortal.transform;

        myRenderPlane.gameObject.GetComponent<Renderer>().material = Instantiate(material);

        if(myCamera.targetTexture != null)
        {
            myCamera.targetTexture.Release();
        }

        myCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);

        myAngle = transform.localEulerAngles.y % 360;
        portalCamera.SetMyAngle(myAngle);
    }

    // Start is called before the first frame update
    void Start()
    {
        myRenderPlane.gameObject.GetComponent<Renderer>().material.mainTexture = otherPortal.myCamera.targetTexture;
    }

    void CheckAngle()
    {
        if(Mathf.Abs(otherPortal.ReturnMyAngle()) != 180)
        {
            float angleDiff = otherPortal.ReturnMyAngle() - ReturnMyAngle();
            Debug.LogWarning("portale nie są odpowiednio ustawione " + gameObject.name);
            Debug.Log("Kąt między nimi: " + (angleDiff));
        }
    }

    public float ReturnMyAngle()
    {
        return myAngle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
