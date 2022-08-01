using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class Hp : MonoBehaviour
    {
        [SerializeField] private Boat boat;
        [SerializeField] private Text text;

        private void Awake()
        {
            boat.OnHpChange -= UpdateHp;
            boat.OnHpChange += UpdateHp;
        }

        private void UpdateHp(int hp)
        {
            text.text = hp.ToString();
        }
    }
}