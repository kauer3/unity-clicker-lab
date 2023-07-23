using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int cookieCount = 0;
    public GameObject cookieText;
    public GameObject clickButton;
    // public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cookieCount = 0;
        // cam = GetComponent<Camera>();
        // cam.clearFlags = CameraClearFlags.SolidColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCookie()
    {
        GameObject clickButton = GameObject.Find("ClickButton");

        // cam.backgroundColor = Color.Lerp(Color.red, Color.blue, 0);
        // cam.backgroundColor = Color.blue;
        // camera.backgroundColor = Color.red;

        // Vector3 currentPos = clickButton.transform.position;
        // Vector3 pos = new Vector3(Random.Range(-300, 300), Random.Range(-300, 300), 0);
        // clickButton.transform.Translate(pos);
        // Debug.Log(GameObject.Find("Main Camera").GetComponent<Camera>().pixelWidth.ToString());

        Vector3 pos = new Vector3(Random.Range(150, 1800), Random.Range(150, 700), 0);
        Quaternion angle = new Quaternion(0, 0, 0, 0);
        clickButton.transform.SetPositionAndRotation(pos, angle);

        Animation anim = clickButton.GetComponent<Animation>();
        anim.Stop();
        cookieCount++;
        UpdateCookie();
        anim.Play("CookieAnimation" + Random.Range(1, 3));

    }

    private void UpdateCookie()
    {
        cookieText.GetComponent<TMP_Text>().text = "Score: " + cookieCount.ToString();
    }
}
