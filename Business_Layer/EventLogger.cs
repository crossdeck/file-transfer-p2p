/*File Transfer is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Foobar is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with File Transfer.  If not, see <http://www.gnu.org/licenses/>.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Business_Layer
{
    public sealed class EventLogger
    {
        /// <summary>
        /// It writes an exception error into the windows event log
        /// </summary>
        /// <param name="ex"></param>
        public static void Logger(Exception ex, string part)
        {
            try
            {
                if (!EventLog.Exists("FTP File Sharing", "."))
                {
                    EventLog.CreateEventSource(new EventSourceCreationData("FTP File Sharing", "FTP File Sharing"));
                }

                EventLog.WriteEntry("FTP File Sharing", part + " : " + ex.Message, EventLogEntryType.Error);
            }
            catch { }
        }
    }
}
