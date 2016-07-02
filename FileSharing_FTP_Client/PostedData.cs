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
using Business_Layer;
using System.Net;
using System.Windows.Forms;

namespace FileSharing_FTP_Client
{
    public class PostedData : Business_Layer.PostedData 
    {
        public event EventHandler RefreshList;  

        public override void ImplementedPostData(string user, byte[] data)
        {

            if (!user.Equals(MachineInfo.GetJustIP()))
                return;

        }

        public override void ImplementedUpdate(string user)
        {
            if (user.Equals(MachineInfo.GetJustIP()))
                return;

            if (RefreshList != null)
                RefreshList(this, null);

            
        }
    }
}
