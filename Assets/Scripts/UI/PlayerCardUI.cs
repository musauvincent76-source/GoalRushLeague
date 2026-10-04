using UnityEngine;
using UnityEngine.UI;

public class PlayerCardUI : MonoBehaviour
{
    public Text playerNameText;
    public Text positionText;
    public Text ratingText;
    public Image playerImage;
    public Slider ratingSlider;

    public void SetPlayerData(PlayerData player)
    {
        playerNameText.text = player.name;
        positionText.text = player.position;
        ratingText.text = player.overallRating.ToString();
        ratingSlider.value = player.overallRating;
    }
}
