/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Configuration;

namespace Dolittle.TimeSeries.Upstreamer.IoTHub
{
    /// <summary>
    /// Represents the <see cref="IConfigurationObject">configuration object</see> for IoTHub
    /// </summary>
    [Name("iothub")]
    public class Configuration : IConfigurationObject
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Configuration"/>
        /// </summary>
        /// <param name="connectionString">The connection string</param>
        public Configuration(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Gets the connection string
        /// </summary>
        public string ConnectionString { get; }
    }
}