using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class Time : MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] private SingleGame game;

        private void Update()
        {
            text.text = game.TimeElapsed.ToString("F2") + " sec";
        }
    }
}