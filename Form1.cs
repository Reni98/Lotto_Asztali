using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gyakorlas_desktop
{
    public partial class Form1 : Form
    {
        List<Lotto> lotto_list = new List<Lotto>();
        public Form1()
        {
            InitializeComponent();
          
            string[] lines = File.ReadAllLines("sorsolas.txt");
            foreach (var item in lines)
            {
                string[] values = item.Split(';');
                Lotto lotto_object = new Lotto(values[0], values[1], values[2], values[3], values[4], values[5]);
                lotto_list.Add(lotto_object);
            }

            label1.Text=("Kérem adjon meg egy számot 1-52 között: ");

            List<Sorsolas> sorsolas_list = new List<Sorsolas>();
            int db = 0;
            for (int i = 1; i < 92; i++)
            {
                foreach (var item in lotto_list)
                {
                    if (i == item.szam1)
                        db++;
                    if (i == item.szam2)
                        db++;
                    if (i == item.szam3)
                        db++;
                    if (i == item.szam4)
                        db++;
                    if (i == item.szam5)
                        db++;
                }
                Sorsolas sorsolas_object = new Sorsolas(i, db);
                sorsolas_list.Add(sorsolas_object);
                db = 0;
            }

            int maxDB = int.MinValue;
            int maxSzam = 0;
            foreach (var item in sorsolas_list)
            {
                if (maxDB < item.db)
                {
                    maxDB = item.db;
                    maxSzam = item.szam;
                }

            }
            label3.Text=($"{maxDB};{maxSzam} ");


            //4.Feladat
            int parosDB = 0;
            foreach (var item in sorsolas_list)
            {
                if (item.szam % 2 == 0)
                {
                    parosDB += item.db;
                }
            }

            label4.Text=($"{parosDB}");


            int db4 = 0;
            int db73 = 0;

            foreach (var item in sorsolas_list)
            {
                if (item.szam == 4)
                {
                    db4 += item.db;
                }
                if (item.szam == 73)
                {
                    db73 += item.db;
                }
            }

            label5.Text=($"{db4}; {db73}");

            foreach (var item in sorsolas_list)
            {
               dataGridView1.Rows.Add( item.szam, item.db );
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int input = (int)numericUpDown1.Value;
            foreach (var item in lotto_list)
            {
                if(input == item.sorszam)
                {
                    label2.Text = ($"{item.sorszam} {item.szam1} {item.szam2} {item.szam3}  {item.szam4}  {item.szam5}");
                }
            }
        }
    }
}
