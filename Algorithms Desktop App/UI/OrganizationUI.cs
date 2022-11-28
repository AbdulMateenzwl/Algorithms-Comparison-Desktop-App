using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms_Desktop_App.BL;
namespace Algorithms_Desktop_App.UI
{
    public class OrganizationUI
    {
        public static void displayAllData(List<Org> vtr)
        {
            Console.Write("{0,-5}", "Index");
            Console.Write("{0,-20}", "Organization ID");
            Console.Write("{0,-35}", "Name");
            Console.Write("{0,-40}", "Name");
            Console.Write("{0,-45}", "Country");
            Console.Write("{0,-60}", "Discription");
            Console.Write("{0,-10}", "Founded");
            Console.Write("{0,-60}", "Industry");
            Console.Write("{0,-30}", "No. of Employees");
            Console.Write("{0,-30}", "\n");
            foreach (var record in vtr)
            {
                Console.Write("{0,-5}", record.index);
                Console.Write("{0,-20}", record.org_id);
                Console.Write("{0,-35}", record.name);
                Console.Write("{0,-40}", record.website);
                Console.Write("{0,-45}", record.country);
                Console.Write("{0,-60}", record.discription);
                Console.Write("{0,-10}", record.founded);
                Console.Write("{0,-60}", record.industry);
                Console.Write("{0,-30}", record.no_emp);
                Console.Write("{0,-30}", "\n");
            }
        }
        public static void displayNoEmpData(List<Org> vtr)
        {
            foreach (var record in vtr)
            {
                Console.Write(record.no_emp);
                Console.Write("\n");
            }
        }
        public static void displayIndexesData(List<Org> vtr)
        {
            foreach (var record in vtr)
            {
                Console.Write(record.index);
                Console.Write("\n");
            }
        }
    }
}
