using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class hintcontroller : MonoBehaviour
{

    public TextMeshProUGUI hintText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(showHint());
        }
    }
    IEnumerator showHint()
    {

        var hint = QuestionManager.getInstance().getHintFromCurrentQuestion();

        hintText.text = hint;

        yield return new WaitForSeconds(1.75f);

        hintText.text = "";


    }

}
