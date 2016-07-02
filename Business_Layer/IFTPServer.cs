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
using System.Reflection;

namespace Business_Layer
{
    public delegate void PostedDataHandler(string user , byte[] data);
    public delegate void UpdateHandler(string user);

    [Serializable()]
    public struct UploadData
    {
        public string Filename;
        public byte[] File;
    }

    public interface IFTPServer
    {
        void Upload(string user,List<UploadData> files);
        void Download(string user,string filename, out byte[] file);
        void GetFiles(out List<FileInfo> files);
        void Connect(string user);
        void Disconnect(string user);
        void PostData(string user, byte[] data);
        event PostedDataHandler PostedData;
        event UpdateHandler Update;

    }

    public abstract class PostedData : System.MarshalByRefObject 
    {
        public void Server_PostData(string user, byte[] data)
        {
            this.ImplementedPostData(user, data);
        }

        public void Server_Update(string user)
        {
            this.ImplementedUpdate(user);
        }

        public abstract void ImplementedPostData(string user, byte[] data);

        public abstract void ImplementedUpdate(string user);
    }
}
