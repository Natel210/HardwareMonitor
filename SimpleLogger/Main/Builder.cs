﻿using SimpleLogger.Interface;
using SimpleLogger.Internal;
using SimpleLogger.UserProperties;
using System.Linq;

namespace SimpleLogger.Main
{
    public static class Builder
    {
        public static ILogger? Create(string logName, LoggerProperties loggerProperties = new LoggerProperties())
        {
            if (logName is null)
                return null;
            if (ExistLogger(logName) is true)
                return Get(logName);
            _logDic.Add(logName, new LoggerItem());
            return Get(logName);
        }


        public static bool Add(string logName, ILogger loggerInstance)
        {
            if (ExistLogger(logName) is true)
                return false;
            _logDic.Add(logName, loggerInstance);
            return true;
        }

        public static ILogger? Get(string logName)
        {
            if (ExistLogger(logName) is false)
                return null;
            _logDicMutex.WaitOne();
            ILogger tempLogger = _logDic[logName];
            _logDicMutex.ReleaseMutex();
            return tempLogger;

        }
        public static ILogger? GetDefault()
        {
            var tempLogger = Get(_defaultLog);
            if (tempLogger is null)
                Create(_defaultLog);
            return Get(_defaultLog);
        }


        private static bool ExistLogger(string logName)
        {
            bool result = false;
            _logDicMutex.WaitOne();
            result = _logDic.ContainsKey(logName);
            _logDicMutex.ReleaseMutex();
            return result;
        }

        private static Dictionary<string, ILogger> _logDic = new();
        private static Mutex _logDicMutex = new();
        private static readonly string _defaultLog = "default";
        static Builder()
        {
            Create(_defaultLog);
        }


    }
}
