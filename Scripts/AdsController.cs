using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;
using UnityEngine;

public class AdsController : MonoBehaviour
{
    private string GooglePlay_ID = "4113833";
    private bool gameMode = true;

    #region Singleton
    private static AdsController _instance;

    public static AdsController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AdsController>();
                if (_instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = typeof(AdsController).Name;
                    _instance = go.AddComponent<AdsController>();
                    DontDestroyOnLoad(go);
                }
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Advertisement.Initialize(GooglePlay_ID, gameMode);
    }
    #endregion


    public void DisplayInterstitialAD()
    {
        Advertisement.Show();
    }
}
