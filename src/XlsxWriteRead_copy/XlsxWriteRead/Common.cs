using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace XlsxWriteRead
{
    public class Common
    {
        #region 移动无边框窗体

        public static Point point;
        static bool down = false;

        public static void MouseDownForm(Form form, MouseEventArgs e)
        {
            point = new Point(e.X, e.Y);
            down = true;
        }

        public static void MouseMoveForm(Form form, MouseEventArgs e)
        {
            if (down == true)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point mousePosition = Control.MousePosition;
                    mousePosition.Offset(-point.X, -point.Y);
                    form.DesktopLocation = mousePosition;
                }
            }
        }

        #endregion

        #region 删除文件列表中文件

        public static void DeleteFileFromList(ref List<string> file_list)
        {
            int file_count = file_list.Count;
            for (int i_file = 0; i_file < file_count; i_file++)
            {
                try
                {
                    if (File.Exists(file_list[i_file]))
                    {
                        FileInfo file = new FileInfo(file_list[i_file]);
                        if (file.Attributes.ToString().IndexOf("ReadOnly") != -1)
                        {
                            file.Attributes = FileAttributes.Normal;
                        }

                        File.Delete(file_list[i_file]);
                    }
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        }

        #endregion
    }
}
