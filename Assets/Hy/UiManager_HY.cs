using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager_HY : MonoBehaviour
{
    //광과민성주의 캔버스
    public GameObject startPanel;
    //실제 게임 시작 캔버스
    public GameObject startGamePanel;
    private void Awake()
    {

       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //광과민성주의 패널에서 게임시작 버튼을 누르면 실행할 함수
    public void gameStart()
    {
        startPanel.SetActive(false);
        startGamePanel.SetActive(true);
    }
}
