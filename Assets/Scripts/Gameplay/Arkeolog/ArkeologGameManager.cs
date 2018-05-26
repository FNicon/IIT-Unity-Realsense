using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArkeologGameManager : MonoBehaviour
{

    public GameObject artifactsPos;
    public Slider slider;
    private int currentLevel;
    private bool isLevellingUp;
    private List<Transform> artifact;
    private List<Transform> artifactDusts;
    public float levelUpSpeed;
    public GameObject endPanel;
    private bool once = false;
    public SFXManager soundEffects;
    public SFXManager bersihSound;
    private bool onceAnimate;
    // Use this for initialization
    void Start()
    {
        artifact = new List<Transform>();
        artifactDusts = new List<Transform>();

        foreach (Transform trans in artifactsPos.transform)
        {
            artifact.Add(trans);
            Debug.Log(trans.name + " is child of " + trans.parent);
        }
        Debug.Log("There are " + artifact.Count + " artifacts");
        // Debug.Log("My name is " + artifact[0].name);
        // Debug.Log("My name is " + artifact[1].name);
        // Debug.Log("My name is " + artifact[2].name);
        currentLevel = 0;
        SetupLevel(currentLevel);
        TimeManager.Timesup += GameOver;
    }

    // Update is called once per frame
    void Update()
    {
        float sliderHealth = 0;
        foreach (Transform trans in artifactDusts)
        {
            sliderHealth += trans.GetComponent<SpriteRenderer>().color.a;
        }
        slider.value = sliderHealth;
        if (currentLevel < artifact.Count)
        {
            if (isLevellingUp)
            {
                LevelUp();
            }
            else if (slider.value <= 0)
            {
                currentLevel++;
                if (!onceAnimate) {
                    onceAnimate = true;
                    //Scale and glow artifacts
                    StartCoroutine(ScaleAndGrow(currentLevel - 1));
                }
                if (currentLevel <= artifact.Count - 1) {
                    SetupLevel(currentLevel);
                }
                bersihSound.PlayFromString("bersih");
                LevelUp();
                ScoreManager.instance.AddScore();
            }
            else
            {
                //Win Screen
                ShowWinScreen();
            }
        } else {
            GameOver();
        }
    }

    IEnumerator ScaleAndGrow(int index) {
        Animator artifactAnimation;
        artifactAnimation = artifact[index].GetComponent<Animator>();
        artifactAnimation.SetBool("isGlowing",true);
        Debug.Log("AAAAAA");
        yield return new WaitUntil(()=>artifactAnimation.GetCurrentAnimatorStateInfo(0).IsName("Glow End"));
        Debug.Log("BBBBBBBB");
        
        onceAnimate = false;
        isLevellingUp = true;
    }

    void LevelUp()
    {
        Vector2 currentPos = artifactsPos.transform.position;
        if (currentPos.x < currentLevel * 15f)
        {
            Vector2 newPos = new Vector2(currentPos.x + levelUpSpeed, currentPos.y);
            artifactsPos.transform.position = newPos;
        }
        else
        {
            isLevellingUp = false;
        }
    }

    void SetupLevel(int n)
    {
        artifactDusts.Clear();
        Debug.Log("This is artifact no " + n);
        foreach (Transform trans in artifact[n].transform)
        {
            artifactDusts.Add(trans);
            Debug.Log(trans.name + " is child of " + trans.transform.parent);
        }
        ResetSlider((float)artifactDusts.Count);
    }

    void ResetSlider(float n)
    {
        Debug.Log("Reset value to " + n);
        slider.maxValue = n;
        slider.value = n;
    }

    void ShowWinScreen()
    {
        // //position artifact 1
        // artifact[0].position = new Vector2(0, 20);

        // //position artifact 2
        // artifact[1].position = new Vector2(-4, 19);
        // artifact[1].rotation = new Quaternion.Euler(45, 0, 0);
        
        // //position artifact 3
        // artifact[2].position = new Vector2(4, 19);
        // artifact[1].rotation = new Quaternion.Euler(-45, 0, 0);
    }

    public void GameOver(){
        if (!once) {
            once = true;
            endPanel.SetActive(true);
            Animator anim = endPanel.GetComponentInChildren<Animator>();
            anim.SetInteger("STATE", ScoreManager.instance.GetNumberOfStar());
            soundEffects.PlayFromString(ScoreManager.instance.GetNumberOfStar().ToString());
            TimeManager.instance.PauseGame();
            //Time.timeScale = 0;
            Debug.Log("GAME OVER");
            Debug.Log("Star = " + ScoreManager.instance.GetNumberOfStar());
        }
	}
}
