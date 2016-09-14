﻿// <copyright file="GedcomParserMessage.cs" company="GeneGenie.com">
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
//
// You should have received a copy of the GNU Affero General Public License
// along with this program. If not, see http:www.gnu.org/licenses/ .
//
// </copyright>
// <author> Copyright (C) 2016 Ryan O'Neill r@genegenie.com </author>

namespace GeneGenie.Gedcom
{
    using System.Collections.Generic;
    using GeneGenie.Gedcom.Enums;

    /// <summary>
    /// A message generated by the GEDCOM file parsing process to provide feedback to the user on warnings, errors and information.
    /// </summary>
    public class GedcomParserMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GedcomParserMessage"/> class.
        /// </summary>
        /// <param name="messageId">The message identifier, from the master list of enums.</param>
        /// <param name="additional">A bunch of context parameters that are relevant to this message id.</param>
        public GedcomParserMessage(ParserMessageIds messageId, object[] additional)
        {
            MessageId = messageId;
            AdditionalData.AddRange(additional);
        }

        /// <summary>
        /// Gets the additional data that was logged with the message for context.
        /// </summary>
        public List<object> AdditionalData { get; } = new List<object>();

        /// <summary>
        /// Gets or sets the message id uniquely identifying where this message was generated from in code.
        /// </summary>
        public ParserMessageIds MessageId { get; set; }

        /// <summary>
        /// Gets the severity of the message. This is fixed here for now as it is very simple.
        /// </summary>
        public ParserMessageIdSeverity Severity
        {
            get
            {
                if ((int)MessageId <= 100)
                {
                    return ParserMessageIdSeverity.Information;
                }

                if ((int)MessageId <= 200)
                {
                    return ParserMessageIdSeverity.Warning;
                }

                if ((int)MessageId <= 300)
                {
                    return ParserMessageIdSeverity.Error;
                }

                return ParserMessageIdSeverity.Unknown;
            }
        }
    }
}