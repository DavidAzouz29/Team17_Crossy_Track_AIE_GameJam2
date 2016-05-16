using UnityEngine;
using System.Collections;

public class UVScrolling : MonoBehaviour {
    public MeshRenderer r_MeshSlime;
    public float uiTilingX = 25.0f; 

    // Use this for initialization
    void Start () {
        //r_ShaderSlime = GetComponent<Shader>();
        r_MeshSlime = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update () {
        Time.timeScale = 0.03f;
        uiTilingX += Time.deltaTime * Time.timeScale;
        //Debug.Log(uiTilingX);
        r_MeshSlime.sharedMaterial.SetTextureOffset("_MainTex", new Vector2(uiTilingX, 25));
        if (uiTilingX >= 100)
        {
            uiTilingX = 0;
        }
        Time.timeScale = 1f;
    }
}
