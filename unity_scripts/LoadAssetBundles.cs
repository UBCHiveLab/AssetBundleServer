using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadAssetBundles : MonoBehaviour
{

    public string assetName;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetAssetBundle());
    }

    IEnumerator GetAssetBundle()
    {
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle("http://127.0.0.1:10070/assets/heart");
        Debug.Log("sending request");
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("instantiating");
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
            InstantiateObjectFromBundle(bundle);
        }
    }

    void InstantiateObjectFromBundle(AssetBundle bundle)
    {
        var prefab = bundle.LoadAsset(assetName);
        Instantiate(prefab);
        Debug.Log("finished instantiating");
    }
}
