using OsEngine.Charts.CandleChart.Indicators;
using OsEngine.Entity;
using OsEngine.Market;
using OsEngine.OsTrader.Panels;
using OsEngine.OsTrader.Panels.Tab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsEngine.Robots.Trend
{
    class MomentumMT_MACD : BotPanel
    {
        public MomentumMT_MACD(string name, StartProgram startProgram) : base(name, startProgram)
        {
            // вкладка для торговли
            TabCreate(BotTabType.Simple);
            _tabToTrade = TabsSimple[0];

            // индикаторы 
            _momentum_more = new Momentum(name + "_momentum_more", false);
            _momentum_more = (Momentum)_tabToTrade.CreateCandleIndicator(_momentum_more, "Momentum");
            _momentum_more.Save();

            _momentum_less = new Momentum(name + "_momentum_less", false);
            _momentum_less = (Momentum)_tabToTrade.CreateCandleIndicator(_momentum_less, "Momentum");
            _momentum_less.Save();

            _macd = new MacdLine(name + "Macd", false);
            _macd = (MacdLine)_tabToTrade.CreateCandleIndicator(_macd, "MacdArea");
            _macd.Save();

            //параметры для моментума 
            _isOn = CreateParameter("IsOn", false);
            _volume = CreateParameter("Volume", 100, 10, 100, 0.5m);
            _length_mom_more = CreateParameter("Length  Momentum_More", 60, 5, 60, 5);
            _length_mom_less = CreateParameter("Length  Momentum_Less", 30, 5, 30, 5);

            _tabToTrade.CandleFinishedEvent += _tabToTrade_CandleFinishedEvent;

            ParametrsChangeByUser += MomentumMultiTimeframe_ParametrsChangeByUser;
        }

        private void MomentumMultiTimeframe_ParametrsChangeByUser()
        {
            _momentum_more.Nperiod = _length_mom_more.ValueInt;
            _momentum_less.Nperiod = _length_mom_less.ValueInt;
        }

        // вкладка
        private BotTabSimple _tabToTrade;

        // индикаторы Моментума и MACD
        private Momentum _momentum_more;
        private Momentum _momentum_less;
        private MacdLine _macd;

        // параметры
        private StrategyParameterBool _isOn;
        private StrategyParameterDecimal _volume;
        private StrategyParameterInt _length_mom_more;
        private StrategyParameterInt _length_mom_less;

        // переменные для торговой логики
        private decimal _lastMacdUp;
        private decimal _lastMacdDown;

        public override string GetNameStrategyType()
        {
            return "MMT_MACD";
        }

        public override void ShowIndividualSettingsDialog()
        {
            throw new NotImplementedException();
        }

        private void _tabToTrade_CandleFinishedEvent(List<Candle> candles)
        {
            // работ включен
            if (_isOn.ValueBool == false)
            {
                return;
            }

            // период меньшего моментума должен быть меньшего периода большего моментума
            if (_momentum_more.Nperiod < _momentum_less.Nperiod)
            {
                return;
            }

            // свечи для индикаторов и вкладка загружены
            if (candles.Count < _length_mom_more.ValueInt || _tabToTrade.IsConnected == false)
            {
                return;
            }

            List<Position> positions = _tabToTrade.PositionsOpenAll;
            var _lastCandle = candles[candles.Count - 1];


            // пересечение моментумов снизу в верх
            var directionUp = _momentum_less.Values[_momentum_less.Values.Count - 1] >
                        _momentum_less.Values[_momentum_less.Values.Count - 2] &&
                        _momentum_more.Values[_momentum_more.Values.Count - 1] >
                        _momentum_more.Values[_momentum_more.Values.Count - 2];

            // пересечение моментумов сверху в низ 
            var directionDown = _momentum_less.Values[_momentum_less.Values.Count - 1] <
                   _momentum_less.Values[_momentum_less.Values.Count - 2] &&
                   _momentum_more.Values[_momentum_more.Values.Count - 1] <
                   _momentum_more.Values[_momentum_more.Values.Count - 2];

            _lastMacdUp = _macd.ValuesUp[_macd.ValuesUp.Count - 1];
            _lastMacdDown = _macd.ValuesDown[_macd.ValuesDown.Count - 1];

            // сделок нет
            if (positions.Count == 0)
            {
                if (directionUp)
                {
                    if(_lastMacdUp > _lastMacdDown)
                    {
                        _tabToTrade.BuyAtMarket(_volume.ValueDecimal);
                    }
                }

                if (directionDown)
                {
                    if(_lastMacdUp < _lastMacdDown)
                    {
                        _tabToTrade.SellAtMarket(_volume.ValueDecimal);
                    }
                }
            }

            // позиция лонг
            else if (positions[0].Direction == Side.Buy)
            {
                // позиция должна быть открыта
                if (positions[0].State != PositionStateType.Open)
                {
                    return;
                }

                if (directionDown || _lastMacdUp < _lastMacdDown)
                {
                    _tabToTrade.CloseAllAtMarket();
                    _tabToTrade.SellAtMarket(_volume.ValueDecimal);
                }
            }

            // позиция шорт
            else if (positions[0].Direction == Side.Sell)
            {
                // позиция должна быть открыта
                if (positions[0].State != PositionStateType.Open)
                {
                    return;
                }

                if (directionUp || _lastMacdUp > _lastMacdDown)
                {
                    _tabToTrade.CloseAllAtMarket();
                    _tabToTrade.BuyAtMarket(_volume.ValueDecimal);
                }
            }

        }
    }
}
