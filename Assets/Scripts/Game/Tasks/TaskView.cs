using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Tasks
{
    public sealed class TaskView
        : MonoBehaviour
    {
        [SerializeField] private Image progressBar;
        [SerializeField] private GameObject finishedMarker;
        [SerializeField] private TMP_Text descriptionText;
        
        public void SetProgress(float progress)
        {
            progressBar.fillAmount = progress;
        }

        public void SetFinished()
        {
            finishedMarker.SetActive(true);
        }

        public void SetDescription(string description)
        {
            descriptionText.text = description;
        }
    }
}