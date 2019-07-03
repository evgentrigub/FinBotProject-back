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
    class GAP : BotPanel
    {
        public GAP(string name, StartProgram startProgram) : base(name, startProgram)
        {
            TabCreate(BotTabType.Simple);
            _tabToTrade = TabsSimple[0];

            _ma = new MovingAverage(name + "MA", false);
            _ma = (MovingAverage)_tabToTrade.CreateCandleIndicator(_ma, "Prime");
            _ma.Save();

            _isOn = CreateParameter("IsOn", false);
            _lengthMa = CreateParameter("Length MA", 20, 20, 100, 5);
            _volume = CreateParameter("Volume", 100, 10, 100, 0.5m);
            gap_min = 0;
            gap_max = 0;

        _tabToTrade.CandleFinishedEvent += _tabToTrade_CandleFinishedEvent;

            ParametrsChangeByUser += GAP_ParametrsChangeByUser;
        }

        private void GAP_ParametrsChangeByUser()
        {
            _ma.Lenght = _lengthMa.ValueInt;
        }

        private BotTabSimple _tabToTrade;

        private MovingAverage _ma;

        private StrategyParameterBool _isOn;
        private StrategyParameterInt _lengthMa;
        private StrategyParameterDecimal _volume;
        private decimal gap_min;
        private decimal gap_max;

        public override string GetNameStrategyType()
        {
            return "GAP";
        }

        public override void ShowIndividualSettingsDialog()
        {
            throw new NotImplementedException();
        }

        private void _tabToTrade_CandleFinishedEvent(List<Candle> candles)
        {
            if (_isOn.ValueBool == false)
            {
                return;
            }

            List<Position> positions = _tabToTrade.PositionsOpenAll;
            var _lastCandle = candles[candles.Count - 1];

            if(positions.Count == 0)
            {
                var length = (double)candles[candles.Count - 2].Close * 0.2 ;
                if ((double)_lastCandle.Open < (double)candles[candles.Count-2].Close + length && 
                    _ma.Values[_ma.Values.Count - 2] < _ma.Values[_ma.Values.Count - 1]) 
                {
                    gap_min = candles[candles.Count - 2].Close;
                    _tabToTrade.BuyAtMarket(_volume.ValueDecimal);
                }
                if ((double)_lastCandle.Open > (double)candles[candles.Count - 2].Close + length &&
                    _ma.Values[_ma.Values.Count - 2] > _ma.Values[_ma.Values.Count - 1])
                {
                    gap_max = candles[candles.Count - 2].Close;
                    _tabToTrade.SellAtMarket(_volume.ValueDecimal);
                }
            }

            if(positions[0].Direction == Side.Buy)
            {
                if (positions[0].State != PositionStateType.Open)
                {
                    return;
                }

                if (_lastCandle.High > gap_min)
                {
                    _tabToTrade.CloseAllAtMarket();
                }
            }

            if(positions[0].Direction == Side.Sell)
            {
                if (positions[0].State != PositionStateType.Open)
                {
                    return;
                }

                if (_lastCandle.High < gap_max)
                {
                    _tabToTrade.CloseAllAtMarket();
                }
            }
        }
    }
}
