using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField]
        public Image dialogue_box;
        [SerializeField]
        public TextMeshProUGUI dialogue_text;
        [SerializeField]
        public Dialogue current_dialogue;
        [SerializeField]
        public bool typing;
        [SerializeField]
        public int index;
        [SerializeField]
        public bool dialogue_box_visible;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                if (!dialogue_box_visible)
                {
                    dialogue_box_visible = true;
                    ShowDialogue();
                }
                ReadLine();
            }
        }

        public void LoadDialogue(Dialogue current_dialogue)
        {
            this.current_dialogue = current_dialogue;
            ResetDialogue();
        }

        public void ResetDialogue()
        {
            index = 0;
            dialogue_text.text = "";
        }

        public void ReadLine()
        {
            if (typing)
            {
                //If it's still typing, then abort all coroutine and adjust ui
                typing = false;
                StopAllCoroutines();
                dialogue_text.text = current_dialogue.GetLineByIndex(index-1);
                return;
            }

            //Otherwise get next line
            string line= current_dialogue.GetLineByIndex(index);
            index++;
            if (line == null)
            {
                CloseDialogue();
                return;
            }
            StartCoroutine(TypeText(line));
        }

        private IEnumerator TypeText(string complete_line)
        {
            typing = true;
            int i = 0;
            bool completed = false;
            string line = "";

            while (!completed)
            {
                line += complete_line[i];
                dialogue_text.text = line;
                i++;
                completed = (i == complete_line.Length);
                yield return new WaitForSeconds(current_dialogue.speed);
            }
            typing = false;
        }

        public void ShowDialogue()
        {
            float begin = Time.time;
            IEnumerator AppearDialogueBox()
            {
                while (Time.time - begin <= 1)
                {
                    dialogue_box.GetComponent<RectTransform>().offsetMax = Vector3.Lerp(dialogue_box.GetComponent<RectTransform>().offsetMax, new Vector2(0, 0), Time.time - begin);
                    dialogue_box.GetComponent<RectTransform>().offsetMin = Vector3.Lerp(dialogue_box.GetComponent<RectTransform>().offsetMin, new Vector2(0, 0), Time.time - begin);
                    yield return new WaitForEndOfFrame();
                }
            }
            StartCoroutine(AppearDialogueBox());
        }

        public void CloseDialogue()
        {
            dialogue_box_visible = false;
            float begin = Time.time;
            IEnumerator DisappearDialogueBox()
            {
                while (Time.time - begin <= 1)
                {
                    dialogue_box.GetComponent<RectTransform>().offsetMax = Vector3.Lerp(dialogue_box.GetComponent<RectTransform>().offsetMax, new Vector2(0, -300), Time.time - begin);
                    dialogue_box.GetComponent<RectTransform>().offsetMin = Vector3.Lerp(dialogue_box.GetComponent<RectTransform>().offsetMin, new Vector2(0, -300), Time.time - begin);
                    yield return new WaitForEndOfFrame();
                }
                ResetDialogue();
            }
            StartCoroutine(DisappearDialogueBox());
        }
    }
}
