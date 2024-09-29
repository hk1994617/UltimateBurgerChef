using YG;
using UnityEngine;


namespace CarybaraAdventure.UI
{
    public class YGAdsProvider : MonoBehaviour
    {
        public static void TryShowFullsccrenAdWithChance(int chance)
        {
            var random = Random.Range(0, 101);

            if (chance < random)
                 return;
            YandexGame.FullscreenShow();
            
        }


    }

}
