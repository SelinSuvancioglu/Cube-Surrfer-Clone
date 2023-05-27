using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toplayici : MonoBehaviour
{
    GameObject anaKup;
    [SerializeField] GameObject LosePanel;
    public float yukseklik;
    float nextTime;
    //GameObject LosePanel;
    public PlayerController playerController;
    public CameraControl cameraController;
    [SerializeField] GameObject SoundPlayer;
    [SerializeField] AudioClip CubeCollect;
    public bool onPlane;
  //  public int CollectCoinLevel;

    void Start()
    {
        onPlane = true;
        anaKup = GameObject.Find("AnaKüp");
        //yukseklik = -1f;
       // transform.GetChild(0).gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    void Update()
    {
        if (onPlane)
        {
            anaKup.transform.position = new Vector3(transform.position.x, 1.5F + yukseklik, transform.position.z);

            for (int i = 0; i < transform.childCount; ++i)
            {
                transform.GetChild(i).localPosition = new Vector3(0, -1, 0) * i;
                gameObject.GetComponent<BoxCollider>().center = new Vector3(0, -1, 0) * i;
            }
            /* if (transform.childCount == 0)
              {
                  playerController.MoveBool = false;
                  cameraController.MoveBool = false;
                  LosePanel.active = true;
              }*/

        }

    }
    public void YukseklikAzalt()
    {
        yukseklik--;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Topla" && other.gameObject.GetComponent<ToplanabilirKup>().GetToplandiMi() == false && !other.transform.IsChildOf(transform))
        {
            //Debug.Log("Work");
            SoundPlayer.GetComponent<AudioSource>().PlayOneShot(CubeCollect);
            yukseklik += 1;
            other.gameObject.GetComponent<ToplanabilirKup>().ToplandiYap();
            other.gameObject.GetComponent<ToplanabilirKup>().IndexAyarla(yukseklik);
            other.gameObject.transform.parent = this.transform; // toplanabilir küp anaKübün altýnda toplanacak
        }
        else if(other.gameObject.tag == "SideRoadEnter")
        {
            playerController.SideRoadEnter = true;
        }
        else if (other.gameObject.tag == "SideRoadExit")
        {
            playerController.SideRoadEnter = false;
        }
    }

    public void movementStop()
    {
        playerController.MoveBool = false;
        cameraController.MoveBool = false;
    }
    public void OnMovement()
    {
        playerController.MoveBool = true;
        cameraController.MoveBool = true;
    }

    //public void FallIntoPool()
    //{
    //    onPlane = false;
    //    anaKup.transform.position = new Vector3(transform.position.x, 0.5F + yukseklik, transform.position.z);

    //}

}
