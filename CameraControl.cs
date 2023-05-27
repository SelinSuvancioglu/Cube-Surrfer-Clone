using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraControl : MonoBehaviour
{
    public GameObject hedef, takip;
    public Vector3 CameraDistane;
    public Vector3 RotateEnterSideRoadDistane;
    [SerializeField] public Vector3 StartDistane = new Vector3(0.5f, 4.28000021f, -10);
    [SerializeField] Vector3 RotateRight;
    [SerializeField] Vector3 RotateLeft;
    public bool MoveBool = true;
    public PlayerController PlayerControl;
    public GameObject Boy;
    public Vector3 WinDistance = new Vector3(1.62f, 3.48000002f, 15.96f);
    public ToplanabilirKup toplanan;
    public Vector3 DenemeVektoru = new Vector3(1f, 4f, -5f);
    private void LateUpdate()
    {
        if (ToplanabilirKup.win) // oyunu kazand�ktan sonra kameray� �ocu�a zumluyor
        {
            WinCamera();
        }
        // bu de�i�iklik test ama�l� yap�lm��t�r
        else if (MoveBool)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, takip.transform.GetChild(takip.transform.childCount - 1).position + StartDistane, Time.deltaTime);
            // For level 1 rotate left
            if (takip.transform.position.z > 378.62f && SceneManager.GetActiveScene().buildIndex == 0)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, -92.745f, 0)), Time.deltaTime); // a��r a��r d�nd�r�yor (Time.deltaTime a ba�l� olarak)
                //transform.rotation = Quaternion.Euler(0, -92.745f, 0); // direkt d�d�r�yor
                StartDistane = RotateLeft;
            }

            // For level 3 rotate right
            else if (takip.transform.position.z > 148f && SceneManager.GetActiveScene().buildIndex == 2)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 92.745f, 0)), Time.deltaTime);
                StartDistane = RotateRight;
            }
            // For level 5 rotate right
            else if (takip.transform.position.z > 196f && SceneManager.GetActiveScene().buildIndex == 4)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 92.745f, 0)), Time.deltaTime);
                StartDistane = RotateRight;
            }
            // For level 6 yal yol
            else if (PlayerControl.SideRoadEnter == true && SceneManager.GetActiveScene().buildIndex == 5) 
            {
                Level6SideRottateCameraContol();                
            }
            else
            {
                //StartDistane = StartDistane;
                StartDistane = new Vector3(0.5f, 4.28000021f, -10);
            }
        }
        
    }


    void Level6SideRottateCameraContol()
    {
        //Debug.Log("Fonksiyon �al���yor");
        if (takip.transform.position.z <= 60f)
        {
            StartDistane = new Vector3(-5.5f, 4.28000021f, -10);
        }
        else if (takip.transform.position.z > 60f && takip.transform.position.z <= 90f)
        {
            StartDistane = new Vector3(0.5f, 4.28000021f, -10);
        }
        else if (takip.transform.position.z > 90f)
        {
            StartDistane = new Vector3(5.5f, 4.28000021f, -10);
        }

    }

    public void FocusToplayici()
    {
        MoveBool = false;
        this.transform.position = Vector3.Lerp(this.transform.position, takip.transform.position + StartDistane, Time.deltaTime);
    }
    // if player win the level, camera close to player
    public void WinCamera() // bu fonksiyon level 1'de d�zg�n �al��t�
    {
        StartDistane = DenemeVektoru;
        StartDistane = new Vector3(5, 2, 0);
        this.transform.position = Vector3.Lerp(this.transform.position, Boy.transform.position + StartDistane, Time.deltaTime);
    }
}
