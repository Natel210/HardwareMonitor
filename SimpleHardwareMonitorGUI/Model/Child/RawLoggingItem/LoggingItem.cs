﻿using CsvHelper.Configuration.Attributes;
using SimpleFileIO.Log.Csv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHardwareMonitorGUI.Model.Child.RawLoggingItem
{
    class LoggingItem
    {
        [Name("Data Time")]
        public DateTime DateTime { get; set; } = new();
        #region Cpu
        [Name("CPU CoreCount")]
        public int CpuCoreCount { get; set; } = 0;
        [Name("CPU ProcessorCount")]
        public int CpuProcessorCount { get; set; } = 0;
        [Name("CPU Use")]
        public float CpuUse { get; set; } = 0;
        [Name("CPU UseByThreads")]
        [TypeConverter(typeof(CSVLogListConverter<float>))]
        public List<float> CpuUseByThreads { get; set; } = [];
        [Name("CPU Voltage")]
        public float CpuVoltage { get; set; } = 0.0f;
        [Name("CPU VoltageByCore")]
        [TypeConverter(typeof(CSVLogListConverter<float>))]
        public List<float> CpuVoltageByCore { get; set; } = [];
        [Name("CPU Power")]
        public float CpuPower { get; set; } = 0.0f;
        [Name("CPU PowerByCore")]
        [TypeConverter(typeof(CSVLogListConverter<float>))]
        public List<float> CpuPowerByCore { get; set; } = [];
        [Name("CPU Temperature")]
        public float CpuTemperature { get; set; } = 0.0f;
        [Name("CPU TemperatureByCore")]
        [TypeConverter(typeof(CSVLogListConverter<float>))]
        public List<float> CpuTemperatureByCore { get; set; } = [];
        #endregion

    }
}
