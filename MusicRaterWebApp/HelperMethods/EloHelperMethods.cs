using MusicRaterWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicRaterWebApp
{
    public class EloHelperMethods
    {
        public EloHelperMethods()
        {
            
        }

        public int getKConstant(int timesSeen, int rank)
        {
            if (timesSeen < 10 || rank < 400)
            {
                return 32;
            }
            if (rank > 500 && rank < 700)
            {
                return 24;
            }
            else
            {
                return 16;
            }
        }

        public int getNewRank(double expected, int result, int K, int rank)
        {
            double gainOrLoss = (result - expected) * K;
            double newRankAsDouble = rank + gainOrLoss;
            if((int)newRankAsDouble < 0)
            {
                return 0;
            }
            return (int)newRankAsDouble;
        }

        public Tuple<double, double> getExpectedScores(double album1ConvertedRating, double album2ConvertedRating)
        {
            var denominator = album1ConvertedRating + album2ConvertedRating;
            Tuple<double, double> returnTuple = Tuple.Create((album1ConvertedRating / denominator), ((album2ConvertedRating / denominator)));
            return returnTuple;
        }

        public double convertRank(int rank)
        {
            return Math.Pow(10, ((double)rank / 500));
        }
    }
}