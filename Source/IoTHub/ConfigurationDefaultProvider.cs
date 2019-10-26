/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Configuration;

namespace Dolittle.TimeSeries.Upstreamer.IoTHub
{
    /// <summary>
    /// Represents the <see cref="ICanProvideDefaultConfigurationFor{T}">default configuration provider</see>
    /// for <see cref="Configuration"/>
    /// </summary>
    public class ConfigurationDefaultProvider : ICanProvideDefaultConfigurationFor<Configuration>
    {
        /// <inheritdoc/>
        public Configuration Provide()
        {
            return new Configuration(string.Empty);
        }
    }
}