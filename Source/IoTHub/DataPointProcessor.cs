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

        /// <summary>
        /// Initializes a new instance of <see cref="DataPointProcessor"/>
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="serializer"></param>
        public DataPointProcessor(ILogger logger, ISerializer serializer)
        {
            _logger = logger;
            var connectionString = "";
            _deviceClient = DeviceClient.CreateFromConnectionString(connectionString);
            _serializer = serializer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataPoint"></param>
        /// <returns></returns>
        [DataPointProcessor]
        public async Task Process(DataPoint<Single> dataPoint)
        {
            var json = _serializer.ToJson(dataPoint);

            _logger.Information($"DataPoint received : {dataPoint.Measurement.Value} : Json: '{json}'");
            var bytes = Encoding.ASCII.GetBytes(json);

            var message = new Message(bytes);

            await _deviceClient.SendEventAsync(message).ConfigureAwait(false);
        }
    }
}