﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// UI输入框
/// </summary>

public class UIInputBox : MonoBehaviour
{
    public Text title;
    public Text message;
    public Text tips;
    public Button buttonYes;
    public Button buttonNo;
    public InputField input;

    public Text buttonYesTitle;
    public Text buttonNoTitle;

    public delegate bool SubmitHandler(string inputText, out string tips);
    public event SubmitHandler OnSubmit;
    public UnityAction OnCancel;

    public string emptyTips;

    public void Init(string title,string message,string btnOK = "",string btnCancel = "",string emptyTips = "")
    {
        if (!string.IsNullOrEmpty(title)) this.title.text = title;
        this.message.text = message;
        this.tips.text = null;
        this.OnSubmit = null;
        this.emptyTips = emptyTips;

        if (!string.IsNullOrEmpty(btnOK)) this.buttonYesTitle.text = title;
        if (!string.IsNullOrEmpty(btnCancel)) this.buttonNoTitle.text = title;

        this.buttonYes.onClick.AddListener(OnClickYes);
        this.buttonNo.onClick.AddListener(OnClickNo);
    }

    private void OnClickYes()
    {
        this.tips.text = "";
        if(string.IsNullOrEmpty(input.text))
        {
            this.tips.text = this.emptyTips;
        }
        if(OnSubmit != null)
        {
            string tips;
            if(!OnSubmit(this.input.text,out tips))
            {
                this.tips.text = tips;
                return;
            }
        }
        Destroy(this.gameObject);
    }

    private void OnClickNo()
    {
        Destroy(this.gameObject);
        if (this.OnCancel!=null)
        {
            this.OnCancel();
        }
    }
}
