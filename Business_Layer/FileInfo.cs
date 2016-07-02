/*File Sharing is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Foobar is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with File Sharing.  If not, see <http://www.gnu.org/licenses/>.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business_Layer
{
    [Serializable()]
    public class FileInfo
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="filename">It is filename value</param>
        /// <param name="size">It is file size value</param>
        public FileInfo(string filename, long size)
        {
            this.Filename = filename;
            this.Size = size;
        }

        /// <summary>
        /// It holds the filename value
        /// </summary>
        public string Filename = string.Empty;

        /// <summary>
        /// It holds the file size value
        /// </summary>
        public long Size = long.MinValue;
    }
}
