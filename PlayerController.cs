using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float ileriGitmeHizi;
    [SerializeField] public float sagaSolaGitmeHizi;
    public bool MoveBool = true;
    public bool Router = true;
    public bool SideRoadEnter = false;
    public bool SideRoadRoate = false;
    public bool SideRoadExit = false;
    [SerializeField] GameObject WinPanel;
    public float SideRoadRotateSecondEnd;
    private float RightLeft;
    float halfWidth = Screen.width / 2;
    public float pointer_x, pointerMobile_x;
    public int P = 5;
    void FixedUpdate()
    {
        pointer_x = Input.GetAxis("Mouse X");
        //Debug.Log("Deðiþken: " + pointer_x);
        if (MoveBool)
        {
            //Deneme();
            //MobileControl(); float yatayEksen = pointerMobile_x * sagaSolaGitmeHizi * Time.deltaTime * 5; // for mobile
            float yatayEksen = pointer_x * sagaSolaGitmeHizi * Time.deltaTime * 5; // for pc

            if (Router)
            {
                // For level 1
                if (this.transform.position.z > 378.62f && SceneManager.GetActiveScene().buildIndex == 0)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, -90, 0)), Time.deltaTime * ileriGitmeHizi);
                    transform.position = new Vector3(transform.position.x - (ileriGitmeHizi * Time.deltaTime), transform.position.y, Mathf.Clamp(transform.position.z + yatayEksen, 378.63f, 387.5f));
                    //transform.rotation = Quaternion.Euler(0, 90, 0); 

                }
                // For level 3
                // For level 3
                else if (this.transform.position.z > 148f && SceneManager.GetActiveScene().buildIndex == 2)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 90, 0)), Time.deltaTime * ileriGitmeHizi);
                    transform.position = new Vector3(transform.position.x + (ileriGitmeHizi * Time.deltaTime), transform.position.y, Mathf.Clamp(transform.position.z - yatayEksen, 149.09f, 157.91f));
                }
                // For level 5
                else if (this.transform.position.z > 196f && SceneManager.GetActiveScene().buildIndex == 4)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 90, 0)), Time.deltaTime * ileriGitmeHizi);
                    transform.position = new Vector3(transform.position.x + (ileriGitmeHizi * Time.deltaTime), transform.position.y, Mathf.Clamp(transform.position.z - yatayEksen, 197.62f, 206.61f));
                }
                // For level 6 yal yol
                else if (SideRoadEnter == true  && SceneManager.GetActiveScene().buildIndex == 5) 
                {
                    level6CallSideRoad();
                }
                else
                {
                    SideRoadEnter = false;
                    transform.rotation = Quaternion.Euler(0, 0f, 0);
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x + yatayEksen, -3.5f, 5.5f), transform.position.y, transform.position.z + (ileriGitmeHizi * Time.deltaTime));
                }
            }

        }
    }

    void level6CallSideRoad()
    {
        if (this.transform.position.z <= 60f)
        {
            transform.position = new Vector3(transform.position.x + (sagaSolaGitmeHizi * Time.deltaTime) * Mathf.Sin(-45f), transform.position.y, transform.position.z + (ileriGitmeHizi * Time.deltaTime));
            transform.rotation = Quaternion.Euler(0, -45f, 0);
        }

        else if (this.transform.position.z > 60f && this.transform.position.z <= 90f)
        {

            transform.position = new Vector3(transform.position.x + (sagaSolaGitmeHizi * Time.deltaTime) * Mathf.Sin(0), transform.position.y, transform.position.z + (ileriGitmeHizi * Time.deltaTime));
            transform.rotation = Quaternion.Euler(0, 0f, 0);
        }
        else if (this.transform.position.z > 90f)
        {
            transform.position = new Vector3(transform.position.x + (sagaSolaGitmeHizi * Time.deltaTime) * Mathf.Sin(45), transform.position.y, transform.position.z + (ileriGitmeHizi * Time.deltaTime)); //  * Mathf.Cos(-135f)
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
    }
    //private void GetInput_Android()
    //{

    //    if (Input.touchCount > 0)
    //    {
    //        if (Input.GetTouch(0).deltaPosition.x >= halfWidth)
    //        {// sað taraf
    //           // RightLeft += 0.1f;
    //            RightLeft =1;
    //            float yatayEksen = Input.GetAxis("Mouse X") * sagaSolaGitmeHizi * Time.deltaTime * 5 * RightLeft;
    //        }

    //        else if (Input.GetTouch(0).deltaPosition.x < halfWidth)
    //        {// sola gidiþ
    //            RightLeft = -1;

    //            float yatayEksen = Input.GetAxis("Mouse X") * sagaSolaGitmeHizi * Time.deltaTime * 5 * RightLeft;
    //        }
    //    }
    //    else
    //    {
    //        float yatayEksen = Input.GetAxis("Mouse X") * sagaSolaGitmeHizi * Time.deltaTime * 5;

    //    }
    //}
    void MobileControl()
    {
        var halfWidth = Screen.width / 2;
        var touch = Input.GetTouch(0);
        var touchPos = touch.position;

        if (touchPos.x < halfWidth)
        {
            Debug.Log("Left touched!");
            pointerMobile_x = pointerMobile_x - 0.1f;
        }
        else
        {
            Debug.Log("Right touched!");
            pointerMobile_x = pointerMobile_x + 0.1f;
        }
    }

    void Deneme()
    {
        if (pointer_x < 0)
        {
            pointerMobile_x = pointerMobile_x - 0.1f;
            Debug.Log("Left touched!: " + pointerMobile_x);
        }
        else if (pointer_x > 0)
        {
            pointerMobile_x = pointerMobile_x + 0.1f;
            Debug.Log("Right touched!" + pointerMobile_x);
        }
        else
        {
            Debug.Log("Not touched!");
        }
    }

}

