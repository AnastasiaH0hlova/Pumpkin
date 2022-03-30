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
    public Text TextGameObject;

    private string text;
    private int flag_text = 0;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        text = TextGameObject.text;
        TextGameObject.text = "";
        coroutine = TextCoroutine();
        StartCoroutine(coroutine);
        flag_text = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (mark == 0 || mark == 2 )
        {

            zatemnenieImage = zatemnenieObj.GetComponent<Image>();
            zatemnenieImage.color = new Color(zatemnenieImage.color.r, zatemnenieImage.color.g, zatemnenieImage.color.b, zatemnenieImage.color.a - 0.1f * Time.deltaTime);
            if (zatemnenieImage.color.a <= 0.3f) {
                if (mark == 0)
                {   
                    mark = 1;
                }
                if (mark == 2) mark = 3;// + вывести текст ко 2 кадру
                
            }
        }

        if ((Input.anyKey && mark == 1 && flag_text == 1) || (Input.anyKey && mark == 3) )
        {
            flag_skip = true;
            
        }
        if ((mark == 1 && flag_skip ) || (mark == 3 && flag_skip ) )
        {
  
            zatemnenieImage.color = new Color(zatemnenieImage.color.r, zatemnenieImage.color.g, zatemnenieImage.color.b, zatemnenieImage.color.a + 0.2f * Time.deltaTime);
            if (zatemnenieImage.color.a >= 1.0f)
            {
                flag_skip = false;
                if (mark == 1)
                {
                    StopCoroutine(coroutine);
                    background.GetComponent<Image>().sprite = kadr3;
                    track.clip = track2;
                    track.volume = 0.25f;
                    track.Play();
                    mark = 2;
                    
                    TextGameObject.text = "";
                    text = "";
                    text = "Слушай, Ты тоже видишь это?\n Да и пахнет как то странно...\n  Стоп. Это что, дым??\n\n О Боже!! Полицейский участок горит!!\nЧто же произошло?\n В здании же могут быть люди.\nОох, а ведь у меня рабочий день даже не успел начаться :(\n\nВ любом случае, нужно поторопиться и всё разузнать!";
                    TextGameObject.text = "";
                    StartCoroutine(TextCoroutine());
                    flag_text = 1;
                }
                if (mark == 3) {

                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                }
                

            }
        }
        
        
    }

    IEnumerator TextCoroutine()
    {
        foreach (char a in text)
        {
            TextGameObject.text += a;
            yield return new WaitForSeconds(0.08f);
            if (mark == 2) continue;
        }
    }
}
