using UnityEngine;
using UnityEngine.Events;


    [CreateAssetMenu(menuName = "GameData/Channel/CoinSystem", fileName = "CoinSystem")]
    public class CoinSystem : ScriptableObject
    {
        private const string COIN_DATA_KEY_PREF = "Coin_Data";
        public UnityEvent<int> OnUpdated;

        public int Coin
        {
            get => PlayerPrefs.GetInt(COIN_DATA_KEY_PREF, 0);
            set => SetCoin(value);
        }

        public void IncreaseCoin() => Coin++;

        public void IncreaseCoin(int amount) => Coin += amount;

        public void DecreaseCoin() => Coin--;
        public void DecreaseCoin(int amount) => Coin -= amount;

        private void SetCoin(int amount)
        {
            PlayerPrefs.SetInt(COIN_DATA_KEY_PREF, amount);
            OnUpdated?.Invoke(amount);
        }
    }
