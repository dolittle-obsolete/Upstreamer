/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Text;
using System.Threading.Tasks;
using Dolittle.Logging;
using Dolittle.Serialization.Json;
using Dolittle.TimeSeries.DataPoints;
using Dolittle.TimeSeries.DataTypes;
using Microsoft.Azure.Devices.Client;

namespace Dolittle.TimeSeries.Upstreamer.IoTHub
{
    /// <summary>
    /// Represents a <see cref="ICanProcessDataPoints">data point processor</see> that can push messages
    /// to Azure IoT Hub
    /// </summary>
    public class DataPointProcessor : ICanProcessDataPoints
    {
        readonly ILogger _logger;
        readonly DeviceClient _deviceClient;
        readonly ISerializer _serializer;
        readonly Configuration _configuration;

        /// <summary>
        /// Initializes a new instance of <see cref="DataPointProcessor"/>
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="serializer"></param>
        /// <param name="logger"></param>
        public DataPointProcessor(
            Configuration configuration,
            ISerializer serializer,
            ILogger logger)
        {
            _logger = logger;
            _serializer = serializer;
            _configuration = configuration;

            if (IsEnabled) _deviceClient = DeviceClient.CreateFromConnectionString(configuration.ConnectionString);
            else _logger.Information("IoT Hub is not enabled - missing connection string configuration?");
        }

        /// <summary>
        /// Process single data points
        /// </summary>
        /// <param name="dataPoint"><see cref="DataPoint{T}"/> to process</param>
        [DataPointProcessor]
        public async Task Process(DataPoint<Single> dataPoint)
        {
            if (!IsEnabled) return;

            var json = _serializer.ToJson(dataPoint);

            _logger.Information($"DataPoint received : {dataPoint.Measurement.Value} : Json: '{json}'");
            var bytes = Encoding.ASCII.GetBytes(json);

            var message = new Message(bytes);

            await _deviceClient.SendEventAsync(message).ConfigureAwait(false);
        }

        bool IsEnabled => !string.IsNullOrEmpty(_configuration.ConnectionString);
    }
}