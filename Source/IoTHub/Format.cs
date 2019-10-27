/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace Dolittle.TimeSeries.Upstreamer.IoTHub
{
    /// <summary>
    /// Defines supported formats
    /// </summary>
    public enum Format
    {
        /// <summary>
        /// Format used will be binary protobuf
        /// </summary>
        Protobuf = 1,

        /// <summary>
        /// Format used will be JSON
        /// </summary>
        JSON
    }
}