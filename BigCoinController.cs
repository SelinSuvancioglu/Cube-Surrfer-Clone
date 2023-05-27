using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BigCoinController : MonoBehaviour
{
    [SerializeField] float RotateSpeed;
    [SerializeField] public Text CoinCountText;
    [SerializeField] GameObject SoundPlayer;
    [SerializeField] AudioClip CoinCollect;
    public int CoinCount;
    private GameObject Keeper;
    public Text KeeperText;
    public CoinControl CoinController;
    private void Awake()
    {
        Keeper = GameObject.Find("CoinCountNum");
        KeeperText = Keeper.GetComponent<Text>();
    }
    void Update()
    {
        transform.Rotate(new Vector3(0f, RotateSpeed, 0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        // Gives 60 points
        if (other.gameObject.CompareTag("Player"))
        {
            SoundPlayer.GetComponent<AudioSource>().PlayOneShot(CoinCollect);
            CoinCount = int.Parse(KeeperText.text);
            CoinCount = CoinCount +60;
            CoinControl.CollectCoinLevel = CoinControl.CollectCoinLevel + 60;
            CoinControl.a = CoinControl.a + 60;
            Debug.Log("B�y�k paradan toplanan CollectCoinLevel: " + CoinControl.CollectCoinLevel);
            KeeperText.text = CoinCount.ToString();
            Destroy(this.gameObject);
        }
    }

}
