using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class hintcontroller : MonoBehaviour
{

    public TextMeshProUGUI hintText;

    private AudioSource _hintSfx;
    // Start is called before the first frame update
    void Start()
    {
        _hintSfx = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(showHint());
            _hintSfx.Play();
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
