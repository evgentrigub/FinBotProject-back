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
    class MomentumMultiTimeframe : BotPanel
    {
        public MomentumMultiTimeframe(string name, StartProgram startProgram) : base(name, startProgram)
        {
            // вкладка для торговли
            TabCreate(BotTabType.Simple);
            _tabToTrade = TabsSimple[0];

            // индикаторы моментума
            _momentum_more = new Momentum(name + "_momentum_more", false);
            _momentum_more = (Momentum)_tabToTrade.CreateCandleIndicator(_momentum_more, "Prime");
            _momentum_more.Save();

            _momentum_less = new Momentum(name + "_momentum_less", false);
            _momentum_less = (Momentum)_tabToTrade.CreateCandleIndicator(_momentum_less, "Second");
            _momentum_less.Save();

            //параметры для моментума 
            _isOn = CreateParameter("IsOn", false);
            _volume = CreateParameter("Volume", 0.1m, 0.1m, 5, 0.1m);
            _length_mom_more = CreateParameter("Length  Momentum_More", 1, 1, 60, 1);
            _length_mom_less = CreateParameter("Length  Momentum_Less", 1, 1, 30, 1);

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

        // индикаторы Моментума
        private Momentum _momentum_more;
        private Momentum _momentum_less;

        // параметры
        private StrategyParameterBool _isOn;
        private StrategyParameterDecimal _volume;
        private StrategyParameterInt _length_mom_more;
        private StrategyParameterInt _length_mom_less;

        public override string GetNameStrategyType()
        {
            return "MMT_Test";
        }

        public override void ShowIndividualSettingsDialog()
        {
            throw new NotImplementedException();
        }

        //логика торговли
        private void _tabToTrade_CandleFinishedEvent(List<Candle> candles)
        {
            if (_isOn.ValueBool == false)
            {
                return;
            }

            if (_momentum_more.Nperiod < _momentum_less.Nperiod)
            {
                return;
            }

            if (candles.Count < _length_mom_more.ValueInt || _tabToTrade.IsConnected == false)
            {
                return;
            }

            List<Position> positions = _tabToTrade.PositionsOpenAll;

            if (positions.Count == 0)
            {
                // определяем бычий тренд
                if(_momentum_less.Values[_momentum_less.Values.Count - 1] > 
                    _momentum_less.Values[_momentum_less.Values.Count - 2] &&
                    _momentum_more.Values[_momentum_more.Values.Count - 1] >
                    _momentum_more.Values[_momentum_more.Values.Count - 2])
                {
                    _tabToTrade.BuyAtMarket(_volume.ValueDecimal);
                }

                if (_momentum_less.Values[_momentum_less.Values.Count - 1] <
                    _momentum_less.Values[_momentum_less.Values.Count - 2] &&
                    _momentum_more.Values[_momentum_more.Values.Count - 1] <
                    _momentum_more.Values[_momentum_more.Values.Count - 2])
                {
                    _tabToTrade.SellAtMarket(_volume.ValueDecimal);
                }
            }

            else if(positions[0].Direction == Side.Buy)
            {
                if (positions[0].State != PositionStateType.Open)
                {
                    return;
                }

                if (_momentum_less.Values[_momentum_less.Values.Count - 1] <
                    _momentum_less.Values[_momentum_less.Values.Count - 2] &&
                    _momentum_more.Values[_momentum_more.Values.Count - 1] <
                    _momentum_more.Values[_momentum_more.Values.Count - 2])
                {
                    _tabToTrade.CloseAllAtMarket();
                    //_tabToTrade.SellAtMarket(_volume.ValueDecimal);
                }
            }

            else if(positions[0].Direction == Side.Sell)
            {
                if (positions[0].State != PositionStateType.Open)
                {
                    return;
                }

                if (_momentum_less.Values[_momentum_less.Values.Count - 1] >
                    _momentum_less.Values[_momentum_less.Values.Count - 2] &&
                    _momentum_more.Values[_momentum_more.Values.Count - 1] >
                    _momentum_more.Values[_momentum_more.Values.Count - 2])
                {
                    _tabToTrade.CloseAllAtMarket();
                    //_tabToTrade.BuyAtMarket(_volume.ValueDecimal);
                }
            }
        }
    }
}
