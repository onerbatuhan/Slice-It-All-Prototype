using System;
using Game.Scripts.Pattern;
using Game.Scripts.TableObjects.Money;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.EconomyControls
{
    public class MoneyController : Singleton<MoneyController>
    {
        public int currentMoney;
        public MoneyTableObjects moneyTableObject;
        public Text moneyText;
        private bool _stateMoneyMultiply;

        private void Start()
        {
            currentMoney = moneyTableObject.moneyData;
        }

        public void MoneyIncrease(int value)
        {
            currentMoney += value;
            MoneyAddData();
        }

        public void MoneyDecrease(int value)
        {
            currentMoney -= value;
            MoneyAddData();
        }

        public void MoneyMultiply(int value)
        {
            if (!_stateMoneyMultiply)
            {
                _stateMoneyMultiply = true;
                currentMoney *= value;
                MoneyAddData();
            }
        }

        private void MoneyAddData()
        {
            moneyTableObject.moneyData = currentMoney;
        }

        private void LateUpdate()
        {
            moneyText.text = currentMoney.ToString();
        }
    }
}
