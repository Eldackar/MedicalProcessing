using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public static class ImportExportJson
    {
        public static string Export()
        {
            string json = JsonConvert.SerializeObject(Form1.fltobj);
            return json;
        }

        public static void Import(string input)
        {
            try
            {
                Form1.fltobj = JsonConvert.DeserializeObject<filterObject>(input);
            }
            catch
            {
                MessageBox.Show("Your file is corrupted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

    }
}
