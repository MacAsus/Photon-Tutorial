using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace Com.MyCompany.MyGame
{
    [RequireComponent(typeof(InputField))]
    public class PlayerNameInputField : MonoBehaviour
    {
        static string playerNamePrefKey = "PlayerName";

        private void Start()
        {
            string defaultName = "";
            InputField _inputField = this.GetComponent<InputField>();
            if(_inputField != null)
            {
                Debug.Log(defaultName);
                if (PlayerPrefs.HasKey(playerNamePrefKey))
                {
                Debug.Log(defaultName);
                    defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                    _inputField.text = defaultName;
                }
            }
            Debug.Log(defaultName);
            PhotonNetwork.playerName = defaultName;
        }

        public void SetPlayerName(string value)
        {
            PhotonNetwork.playerName = value + " ";
            PlayerPrefs.SetString(playerNamePrefKey, value);
            Debug.Log(value);
        }
    }
}