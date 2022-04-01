using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CutScene1 : MonoBehaviour
{
    public GameObject zatemnenieObj;
    public GameObject background;
    public AudioSource track;
    public Image backgroundImage;
    public AudioClip track2;
    public Sprite kadr2;
    public Sprite kadr3;
    public Image zatemnenieImage;
    public int mark = 0;
    public bool flag_skip = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (mark == 0 || mark == 2 || mark == 4)
        {

            zatemnenieImage = zatemnenieObj.GetComponent<Image>();
            zatemnenieImage.color = new Color(zatemnenieImage.color.r, zatemnenieImage.color.g, zatemnenieImage.color.b, zatemnenieImage.color.a - 0.1f * Time.deltaTime);
            if (zatemnenieImage.color.a <= 0.3f) {
                if (mark == 0) mark = 1;// + вывести текст к 1 кадру
                if (mark == 2) mark = 3;// + вывести текст ко 2 кадру
                if (mark == 4) mark = 5;// + вывести текст к 3 кадру
            }
        }
        
        if ((Input.anyKey && mark == 1) || (Input.anyKey && mark == 3) || (Input.anyKey && mark == 5))
        {
            flag_skip = true;
        }
        if ((mark == 1 && flag_skip ) || (mark == 3 && flag_skip ) || (mark == 5 && flag_skip))
        {
  
            zatemnenieImage.color = new Color(zatemnenieImage.color.r, zatemnenieImage.color.g, zatemnenieImage.color.b, zatemnenieImage.color.a + 0.2f * Time.deltaTime);
            if (zatemnenieImage.color.a >= 1.0f)
            {
                flag_skip = false;
                if (mark == 1)
                {
                    background.GetComponent<Image>().sprite = kadr2;
                    mark = 2;
                }
                if (mark == 3) {
                    background.GetComponent<Image>().sprite = kadr3;
                    mark = 4;
                    track.clip = track2;
                    track.volume = 0.25f;
                    track.Play();
                }
                if (mark == 5) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }
        }
        
        
    }
    
}
