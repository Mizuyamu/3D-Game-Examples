         using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] private int _coinCount;
    [SerializeField] private TextMeshProUGUI _countCountText;
    [SerializeField] private CanvasGroup _CanvasGroup;
    [SerializeField] private bool _fadeIn, _fadeOut;

    // Start is called before the first frame update
    void Start()
    {
        _coinCount = 0;
        _countCountText.text = "Coins: " + _coinCount.ToString();
        fadeOutUI();
    }

    // Update is called once per frame
    void Update()
    {
        if(_fadeIn)
        {
            if(_CanvasGroup.alpha < 1)
            {
                _CanvasGroup.alpha += Time.deltaTime;
                if(_CanvasGroup.alpha >= 1)
                {
                    _fadeIn = false;
                }
            }
        }

        if(_fadeOut)
        {
            if(_CanvasGroup.alpha >= 0)
            {
                _CanvasGroup.alpha -= Time.deltaTime;
                if(_CanvasGroup.alpha ==0)
                {
                    _fadeOut = false;
                }
            }
        }
    }

    public void FadeInUI()
    {
        _fadeIn = true;
    }
    public void fadeOutUI()
    {
        _fadeOut = true;
    }
}   
