﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicturebotGUI.src.Helper
{
    public static class Helper
    {
        /// <summary>
        /// Static method to Delete a picture within a certain flow
        /// </summary>
        /// <param name="form">Main form of the GUI application</param>
        /// <param name="path">Absolute path to the picture within a certain flow</param>
        /// <param name="confirmation">A confirmation box is shown on when the boolean is set to true</param>
        public static void DeletePicture(Form1 form, string path, bool confirmation = false)
        {
            // Making sure the 'important' flows get a confirmation before a picture is getting deleted
            if (confirmation)
            {
                var result = MessageBox.Show("Are you sure to delete this picture ?", "Confirm Delete!!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                        form.UpdateBaseListBox();
                    }
                }
            }
            else
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    form.UpdateBaseListBox();
                }
            }
        }

        /// <summary>
        /// Sort pictures in a directory by creation time
        /// </summary>
        /// <param name="path">Path to directory where the pictures are stored</param>
        /// <returns></returns>
        public static string[] SortPicturesByCreationTime(string path)
        {
            string[] files = Directory.GetFiles(path);

            DateTime[] creationTimes = new DateTime[files.Length];

            for (int i = 0; i < files.Length; i++)
                creationTimes[i] = new FileInfo(files[i]).CreationTime;

            return files;
        }
    }
}