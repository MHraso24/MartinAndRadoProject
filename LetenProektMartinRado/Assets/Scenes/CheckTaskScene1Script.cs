using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;
public class CheckTaskScene1Script : MonoBehaviour
{
    [SerializeField] public TMP_InputField InputField1;
    [SerializeField] public TMP_InputField InputField2;
    [SerializeField] public TMP_InputField InputField3;
    [SerializeField] public Button YesHint;
    [SerializeField] public Button NoHint;

    [SerializeField] private Button CheckButton;
    bool InputField1Check = false;
    bool InputField2Check = false;
    bool InputField3Check = false;
    private int counter = 0;
    
    public Image Hint;
    private void Start()
    {
        Hint.gameObject.SetActive(false);
        CheckButton.onClick.RemoveAllListeners();
        CheckButton.onClick.AddListener(OnCheck);


    }
    
    private void OnCheck()
    {


        
            InputField1Check = false;
            InputField2Check = false;
            InputField3Check = false;


            string a = InputField1.text.Replace(" ", "");
            if (a == "Zn+2HCl->ZnCl(2)+H(2)")
            {
                InputField1Check = true;
            }
            Debug.Log(a);
            string b = InputField2.text.Replace(" ", "");
            if (b == "Ca+2H(2)O->Ca(OH)(2)+H(2)")
            {
                InputField2Check = true;
            }
            Debug.Log(b);

            string c = InputField3.text.Replace(" ", "");
            if (c == "CuO+H(2)->Cu+H(2)O")
            {
                InputField3Check = true;
            }
            Debug.Log(c);

            if (InputField1Check == false || InputField2Check == false || InputField3Check == false)
            {
                counter++;
            }
            
                Debug.Log(counter);
            if (counter == 3)
            {
                Hint.gameObject.SetActive(true);
            
            YesHint.onClick.AddListener(() =>
            {
                if (InputField1Check == false)
                {
                    InputField1.text = "Zn+2HCl->ZnCl(2)+H(2)";
                }
                else if (InputField2Check == false)
                {
                    InputField2.text = "Ca+2H(2)O->Ca(OH)(2)+H(2)";

                }else
                {
                    InputField3.text = "CuO+H(2)->Cu+H(2)O";

                }
                Hint.gameObject.SetActive(false);
            });
            NoHint.onClick.AddListener(() =>
            {
                Hint.gameObject.SetActive (false);
            });
            counter = 0;
        }


        }


    }

