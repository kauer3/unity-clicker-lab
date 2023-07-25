using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float cookieCount = 0f;
    public float cps = 0f;
    public int cpsCost = 10;
    // public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(cps > 0f)
        {
            cookieCount += cps * Time.deltaTime;
            UpdateText();
        }
        
    }

    public void AddCookie()
    {

        // cam.backgroundColor = Color.Lerp(Color.red, Color.blue, 0);
        // cam.backgroundColor = Color.blue;
        // camera.backgroundColor = Color.red;

        // Vector3 currentPos = clickButton.transform.position;
        // Vector3 pos = new Vector3(Random.Range(-300, 300), Random.Range(-300, 300), 0);
        // clickButton.transform.Translate(pos);
        // Debug.Log(GameObject.Find("Main Camera").GetComponent<Camera>().pixelWidth.ToString());

        Vector3 pos = new Vector3(Random.Range(150, 1770), Random.Range(150, 800), 0);
        Quaternion angle = new Quaternion(0, 0, 0, 0);

        GameObject clickButton = GameObject.Find("ClickButton");
        Animation anim = clickButton.GetComponent<Animation>();

        clickButton.transform.SetPositionAndRotation(pos, angle);
        anim.Stop();
        anim.Play("PopAnimation" + Random.Range(1, 3));
        cookieCount++;
        UpdateText();
    }

    private void UpdateText()
    {
        GameObject.Find("Scoreboard").GetComponent<TMP_Text>().text = "Cookies Collected: " + cookieCount.ToString("F0");
    }

    public void increaseCPS()
    {
        if(cookieCount >= cpsCost)
        {
            cookieCount -= cpsCost;
            cpsCost *= 2;
            cps++;
            GameObject.Find("CPSText").GetComponent<TMP_Text>().text = "Buy CPS\nCost: " + cpsCost.ToString() + " Cookies";
            UpdateText();
            Debug.Log("Our CPS is now " + cps.ToString());
        }
    }
}
