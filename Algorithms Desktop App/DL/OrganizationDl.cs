using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using Algorithms_Desktop_App.BL;
using Algorithms_Desktop_App.DL;


namespace Algorithms_Desktop_App.DL
{
    public class OrganizationDl
    {
        public static bool contains(string str, char ch)
        {
            int i = 0;
            while (true)
            {
                if (str[i] == '\0')
                {
                    break;
                }
                if (str[i] == ch)
                {
                    return true;
                }
                i++;
            }
            return false;
        }
        public static List<Org> load_data(string file)
        {
            List<Org> ans = new List<Org>();
            if (File.Exists(file))
            {
                string str = "";
                StreamReader var = new StreamReader(file);
                var.ReadLine();
                while ((str = var.ReadLine()) != null)
                {
                    Org record = new Org();
                    string[] splitData = str.Split(',');
                    record.index = int.Parse(splitData[0]);
                    record.org_id = splitData[1];
                    if (str.Contains('"'))
                    {
                        string[] splitcomma = str.Split('"');
                        record.name=splitcomma[1];
                        record.website = splitData[4];
                        record.country = splitData[5];
                        record.discription = splitData[6];
                        record.founded = splitData[7];
                        record.industry = splitData[8];
                        record.no_emp = int.Parse(splitData[9]);
                    }
                    else
                    {
                        record.name = splitData[2];
                        record.website = splitData[3];
                        record.country = splitData[4];
                        record.discription = splitData[5];
                        record.founded = splitData[6];
                        record.industry = splitData[7];
                        record.no_emp = int.Parse(splitData[8]);
                    }
                    ans.Add(record);
                }
                var.Close();
            }
            return ans;
        }
        public static void storetime(long time, string str)
        {
            StreamWriter store = new StreamWriter("time.txt", true);

            store.WriteLine("Time Taken for " + str + " : " + (int)time + "ns");
            store.Close();
        }
        public static void storeData(List<Org> vtr)
        {
            StreamWriter store = new StreamWriter("temp.csv", false);
            store.WriteLine("Index,Organization Id,Name,Website,Country,Description,Founded,Industry,Number of employees");
            foreach (Org record in vtr)
            {
                store.Write(record.index + ",");
                store.Write(record.org_id + ",");
                if (record.name.Contains(','))
                {
                    store.Write('\u0022' + record.name + '\u0022' + ",");
                }
                else
                {
                    store.Write(record.name + ",");
                }
                store.Write(record.website + ",");
                store.Write(record.country + ",");
                store.Write(record.discription + ",");
                store.Write(record.founded + ",");
                store.Write(record.industry + ",");
                store.Write(record.no_emp + "\n");
            }
            store.Close();
        }
    }
}
