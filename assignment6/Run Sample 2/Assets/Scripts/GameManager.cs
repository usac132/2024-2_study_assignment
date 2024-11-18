using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public UIManager MyUIManager;

    public GameObject Character;
    public GameObject CamObj;
    
    const float CharacterSpeed = 3f;

    public int NowScore = 0;

    void Awake()
    {
        MyUIManager.DisplayScore(NowScore);
        MyUIManager.DisplayMessage("", 0);
    }
    
    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
    }

    // For smooth cam moving, it's good to use LateUpdate.
    void LateUpdate()
    {
        MoveCam();
    }

    void MoveCam()
    {
        // CamObj는 Character의 x, y position을 따라간다.
        // ---------- TODO ---------- 
        Vector3 Character_position = new Vector3(Character.transform.position.x, Character.transform.position.y, CamObj.transform.position.z);
        if (Character != null) CamObj.transform.position = Character_position;
        else return;
        // -------------------- 
    }

    void MoveCharacter()
    {
        // Character는 초당 CharacterSpeed의 속도로 우측으로 움직인다.
        // ---------- TODO ---------- 
        if (Character != null) Character.transform.position += Vector3.right * CharacterSpeed * Time.deltaTime;
        else return;
        // -------------------- 
    }

    public void GameOver()
    {
        // Character를 삭제하고, "Game Over!"라는 메시지를 3초간 띄우고, RestartButton을 활성화한다.
        // ---------- TODO ---------- 
        Destroy(Character);
        GameObject.Find("MessageText").GetComponent<UIManager>().MessageText.text = "GameOver";
        float startTime = Time.time;
        while (Time.time - startTime < 3f) {}
        GameObject.Find("RestartButton").SetActive(true);
        // -------------------- 
    }

    public void GetPoint(int point)
    {
        // point만큼 점수를 증가시키고 UI에 표시한다.
        // ---------- TODO ---------- 
        NowScore++;
        GameObject.Find("ScoreText").GetComponent<UIManager>().MessageText.text = NowScore.ToString();
        // -------------------- 
    }

    // Restart the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
