using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.General
{
    public class PlayerPrefsManager
    {

        private void SetCurrentLevel(int levelIndex)
        {
            PlayerPrefs.SetInt("current_level", levelIndex);
        }

        public int GetCurrentLevel()
        {
            return PlayerPrefs.GetInt("current_level", 0);
        }              

        public void NextLevel()
        {
            int currentLevel = GetCurrentLevel();
            if (currentLevel < 4)
            {
                currentLevel = currentLevel + 1;
            }
            else
            {
                currentLevel = 0;
            }
            SetCurrentLevel(currentLevel);
        }


    }
}
