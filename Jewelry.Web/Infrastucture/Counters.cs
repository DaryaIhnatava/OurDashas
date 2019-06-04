using System.Diagnostics;
using NHibernate.Criterion;

namespace Jewelry.Web.Infrastucture
{
    public static class Counters
    {
        private const string categoryName = "JewelryStore";
        private const string loginCounterName = "Login";
        private const string logoffCounterName = "LogOff";
        private const string loginCounterHelp = "Login count";
        private const string logoffCounterHelp = "LogOff count";
        private const string categoryHelp = "JewelryStore app counters";
        private static PerformanceCounter performanceLogInCounter;
        private static PerformanceCounter performanceLogOffCounter;
        
        public static void IncrementLogIn()
        {
            performanceLogInCounter.Increment();
        }

        public static void IncrementLogOff()
        {
            performanceLogOffCounter.Increment();
        }

        public static void CreateCategory(bool isEnableLogInCounter, bool isEnableLogOffCounter)
        {
            if (!isEnableLogInCounter && !isEnableLogOffCounter)
            {
                return;
            }

            if (PerformanceCounterCategory.Exists(categoryName))
            {
                PerformanceCounterCategory.Delete(categoryName);
            }

            CounterCreationDataCollection counters = new CounterCreationDataCollection();
            CounterCreationData counter;
            if (isEnableLogOffCounter)
            {
                counter = new CounterCreationData(logoffCounterName, logoffCounterHelp, PerformanceCounterType.NumberOfItems64);
                counters.Add(counter);
            }

            if (isEnableLogInCounter)
            {
                counter = new CounterCreationData(loginCounterName, loginCounterHelp, PerformanceCounterType.NumberOfItems64);
                counters.Add(counter);
            }

            PerformanceCounterCategory.Create(categoryName,categoryHelp, PerformanceCounterCategoryType.SingleInstance, counters);
            performanceLogOffCounter = new PerformanceCounter(categoryName, logoffCounterName, false);
            performanceLogInCounter = new PerformanceCounter(categoryName, loginCounterName, false);

        }
    }
}
