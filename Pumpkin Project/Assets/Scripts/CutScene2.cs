using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CutScene2 : MonoBehaviour
{
    public GameObject zatemnenieObj;
    public GameObject background;
    public Image backgroundImage;
    public Sprite kadr2;
    public Sprite kadr3;
    public Sprite kadr4;
    public Sprite kadr5;
    public Image zatemnenieImage;
    public int mark = 0;
    public bool flag_skip = true;



    // Start is called before the first frame update
    void Start()
    {
        flag_skip = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (mark == 0 || mark == 2 || mark == 4 || mark == 6 || mark == 8)
        {

            zatemnenieImage = zatemnenieObj.GetComponent<Image>();
            zatemnenieImage.color = new Color(zatemnenieImage.color.r, zatemnenieImage.color.g, zatemnenieImage.color.b, zatemnenieImage.color.a - 0.1f * Time.deltaTime);
            if (zatemnenieImage.color.a <= 0.3f)
            {
                if (mark == 0) mark = 1;
                if (mark == 2) mark = 3;// + ������� ����� �� 2 �����
                if (mark == 4) mark = 5;
                if (mark == 6) mark = 7;
                if (mark == 8) mark = 9;
            }
        }

        /*if ((Input.anyKey && mark == 1) || (Input.anyKey && mark == 3) || (Input.anyKey && mark == 5) || (Input.anyKey && mark == 7)  || (Input.anyKey && mark == 9))
        {
            flag_skip = true;

        }*/
        if ((mark == 1 && flag_skip) || (mark == 3 && flag_skip) || (mark == 5 && flag_skip) || (mark == 7 && flag_skip) || (mark == 9 && flag_skip))
        {

            zatemnenieImage.color = new Color(zatemnenieImage.color.r, zatemnenieImage.color.g, zatemnenieImage.color.b, zatemnenieImage.color.a + 0.2f * Time.deltaTime);
            if (zatemnenieImage.color.a >= 1.0f)
            {
                
                if (mark == 1)
                {  
                    background.GetComponent<Image>().sprite = kadr2;
                    mark = 2;
                }
                if (mark == 3)
                {
                    background.GetComponent<Image>().sprite = kadr3;
                    mark = 4;
                }
                if (mark == 5)
                {
                    background.GetComponent<Image>().sprite = kadr4;
                    mark = 6;
                }
                if (mark == 7) {
                    background.GetComponent<Image>().sprite = kadr5;
                    mark = 8;
                }
                if (mark == 9)  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex);
            }
        }


    }

   
}