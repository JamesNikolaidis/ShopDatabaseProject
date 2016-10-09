using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace APOTHIKI_3777
{
    public partial class Form1 : Form
    {
        SqlConnection con = null;
        String url = @"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Πανεπιστήμιο\Θεωρίες Τ.Ε.Ι\6o Εξάμηνο Θεωρίες(Μηχανικοί Λογισμικού)\Βάσεις Δεδομένων 2\ProjectDatabase\Project_3777.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        SqlDataAdapter daPel, daPar, daAp, dataAdapter1, dataAdapter2, dataAdapter3, daP;
        DataSet dsPel, dsPar, dsAp, dataSet2, dataSet3, dsP;
        BindingSource bsPel, bsPar, bsAp, bindingSource2, bindingSource3, bsP;
        SqlCommandBuilder cmdbl;
        SqlCommand PhotoUpdate;


        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection(url);
            con.Open();
            dataAdapter1 = new SqlDataAdapter("Select * from PELATES", con);
            DataTable dt1 = new DataTable();
            dataAdapter1.Fill(dt1);
            comboBox1.DataSource = dt1;
            comboBox1.DisplayMember = "EPONYMIA";



            dataAdapter3 = new SqlDataAdapter("Select * from APOTHIKI", con);
            DataTable dt2 = new DataTable();
            dataAdapter3.Fill(dt2);
            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "EIDOS";
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Project_3777DataSet.APOTHIKI' table. You can move, or remove it, as needed.
            this.APOTHIKITableAdapter.Fill(this.Project_3777DataSet.APOTHIKI);
            // TODO: This line of code loads data into the 'Project_3777DataSet.PELATES' table. You can move, or remove it, as needed.
            this.PELATESTableAdapter.Fill(this.Project_3777DataSet.PELATES);

            daPel = new SqlDataAdapter("Select * from PELATES", con);
            dsPel = new DataSet();
            daPel.Fill(dsPel);
            bsPel = new BindingSource();
            bsPel.DataSource = dsPel.Tables[0].DefaultView;
            bindingNavigator1.BindingSource = bsPel;
            textBox24.DataBindings.Add(new Binding("Text", bsPel, "KOD_PELATH", true));
            textBox23.DataBindings.Add(new Binding("Text", bsPel, "EPONYMIA", true));
            textBox22.DataBindings.Add(new Binding("Text", bsPel, "EPITHETO", true));
            textBox21.DataBindings.Add(new Binding("Text", bsPel, "ONOMA", true));
            textBox20.DataBindings.Add(new Binding("Text", bsPel, "HM_GENNISIS", true));
            textBox19.DataBindings.Add(new Binding("Text", bsPel, "HLIKIA", true));
            textBox18.DataBindings.Add(new Binding("Text", bsPel, "AFM", true));
            textBox17.DataBindings.Add(new Binding("Text", bsPel, "DOY", true));
            textBox16.DataBindings.Add(new Binding("Text", bsPel, "DIETHINSI", true));
            textBox15.DataBindings.Add(new Binding("Text", bsPel, "POLH", true));
            textBox14.DataBindings.Add(new Binding("Text", bsPel, "THL", true));
            textBox13.DataBindings.Add(new Binding("Text", bsPel, "SXOLIA", true));
            textBox12.DataBindings.Add(new Binding("Text", bsPel, "FOTO", true));
            refreshImage();
            
            
           
            



            daPar = new SqlDataAdapter("Select * from PARAGELIA", con);
            dsPar = new DataSet();
            daPar.Fill(dsPar);
            bsPar = new BindingSource();
            bsPar.DataSource = dsPar.Tables[0].DefaultView;
            bindingNavigator2.BindingSource = bsPar;
            textBox6.DataBindings.Add(new Binding("Text", bsPar, "KOD_PAR", true));
            textBox4.DataBindings.Add(new Binding("Text", bsPar, "K_PEL", true));
            textBox3.DataBindings.Add(new Binding("Text", bsPar, "TROPOS_PLHROMHS", true));
            textBox2.DataBindings.Add(new Binding("Text", bsPar, "TROPOS_PARADOSHS", true));
            textBox5.DataBindings.Add(new Binding("Text", bsPar, "HM_PARAGELIAS", true));





            daAp = new SqlDataAdapter("Select * from APOTHIKI", con);
            dsAp = new DataSet();
            daAp.Fill(dsAp);
            bsAp = new BindingSource();
            bsAp.DataSource = dsAp.Tables[0].DefaultView;
            bindingNavigator3.BindingSource = bsAp;
            textBox9.DataBindings.Add(new Binding("Text", bsAp, "KE", true));
            textBox8.DataBindings.Add(new Binding("Text", bsAp, "EIDOS", true));
            textBox7.DataBindings.Add(new Binding("Text", bsAp, "KATIGORIA", true));
            textBox1.DataBindings.Add(new Binding("Text", bsAp, "APOTHEMA", true));
            textBox11.DataBindings.Add(new Binding("Text", bsAp, "TIMI_POLHSHS", true));
            textBox10.DataBindings.Add(new Binding("Text", bsAp, "FPA", true));




            daP = new SqlDataAdapter("Select * from PROIONTA_PARAGELIAS", con);
            dsP = new DataSet();
            daP.Fill(dsP);
            bsP = new BindingSource();
            bsP.DataSource = dsP.Tables[0].DefaultView;
            bindingNavigator5.BindingSource = bsP;
            textBox27.DataBindings.Add(new Binding("Text", bsP, "K_PAR", true));
            textBox26.DataBindings.Add(new Binding("Text", bsP, "K_E", true));
            textBox25.DataBindings.Add(new Binding("Text", bsP, "POSOTHTA", true));
            







            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
        }

        private void bindingNavigatorPositionItem2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

             

              string sql = "insert into PELATES(EPONYMIA,EPITHETO,ONOMA,HM_GENNISIS,HLIKIA,AFM,DOY,DIETHINSI,POLH,THL,SXOLIA)  values('" +textBox23.Text + "','" +textBox22.Text + "','" +textBox21.Text + "','" + textBox20.Text + "','" + textBox19.Text + "','" + textBox18.Text + "','" + textBox17.Text + "','" + textBox16.Text + "','" + textBox15.Text + "','" + textBox14.Text + "','" + textBox13.Text + "')";
              SqlCommand cmd = new SqlCommand(sql, con);
              cmd.ExecuteNonQuery();


              daPel = new SqlDataAdapter("Select * from PELATES", con);
              dsPel = new DataSet();
              daPel.Fill(dsPel);
              bsPel = new BindingSource();
              bsPel.DataSource = dsPel.Tables[0].DefaultView;
              bindingNavigator1.BindingSource = bsPel;
              
           
                

              




                

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox24.Text = "";
            textBox24.Enabled = false;
            textBox23.Text = "";
            textBox22.Text = "";
            textBox21.Text = "";
            textBox20.Text = "";
            textBox19.Text = "";
            textBox18.Text = "";
            textBox17.Text = "";
            textBox16.Text = "";
            textBox15.Text = "";
            textBox14.Text = "";
            textBox13.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            fillDataSet();


        }


        public void fillDataSet()
        {

            dataAdapter2 = new SqlDataAdapter("Select dbo.PELATES.EPONYMIA,dbo.PELATES.EPITHETO,dbo.PELATES.ONOMA,dbo.PELATES.DOY,dbo.PELATES.AFM,dbo.PELATES.THL,dbo.PELATES.DIETHINSI , dbo.PROIONTA_PARAGELIAS.POSOTHTA ,dbo.APOTHIKI.TIMI_POLHSHS,dbo.APOTHIKI.FPA  from dbo.PELATES inner join (dbo.PARAGELIA inner join ( dbo.PROIONTA_PARAGELIAS  INNER JOIN dbo.APOTHIKI on K_E=KE ) ON KOD_PAR=K_PAR ) ON KOD_PELATH =K_PEL  where dbo.PELATES.EPONYMIA='"+ comboBox1.Text.ToString()+"'", con);
            dataSet2 = new DataSet();
            dataAdapter2.Fill(dataSet2, "Pelates_Table");
            bindingSource2 = new BindingSource();
            DataTable dt = new DataTable();
            bindingSource2.DataSource = dataSet2.Tables[0].DefaultView;
            dataGridView1.DataSource = bindingSource2;

            int i;
            int posotita = 0;
            int fpa = 0;
            double timi=0;
            float posoparagelias = 0;
            double sumwithfpa = 0, sumwithoutfpa = 0;
            

            for (i = 0; i < dataGridView1.Rows.Count; i++)
            {
                posotita = Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
                timi= Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
                fpa = Convert.ToInt32(dataGridView1.Rows[i].Cells[9].Value);
                sumwithfpa += (posotita * timi);
                sumwithoutfpa += posotita*(timi - ((fpa*timi)/100));
            }

            label14.Text = sumwithfpa.ToString();
            label28.Text = sumwithoutfpa.ToString();


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {



            fillDataSetForApothiki();


        }



        public void fillDataSetForApothiki()
        {
           
            dataAdapter3 = new SqlDataAdapter("SELECT dbo.APOTHIKI.EIDOS, dbo.APOTHIKI.KATIGORIA, dbo.APOTHIKI.APOTHEMA, dbo.APOTHIKI.TIMI_POLHSHS, dbo.APOTHIKI.FPA, dbo.PROIONTA_PARAGELIAS.POSOTHTA FROM   dbo.APOTHIKI INNER JOIN  dbo.PROIONTA_PARAGELIAS ON dbo.APOTHIKI.KE = dbo.PROIONTA_PARAGELIAS.K_E WHERE  (dbo.APOTHIKI.EIDOS LIKE '"+ comboBox2.Text.ToString() + "')", con);
            dataSet3 = new DataSet();
            dataAdapter3.Fill(dataSet3);
            bindingSource3 = new BindingSource();
            DataTable dt1 = new DataTable();
            bindingSource3.DataSource = dataSet3.Tables[0].DefaultView;
            dataGridView2.DataSource = bindingSource3;


            int posotita = 0, fpa = 0, i, apothema = 0, eminan = 0;
            double timi = 0;
            float posoparagelias = 0;
            double sumwithfpa = 0, sumwithoutfpa = 0;

            apothema = Convert.ToInt32(dataGridView2.Rows[0].Cells[2].Value);
            
            for (i = 0; i < dataGridView2.Rows.Count; i++)
            {
                posotita += Convert.ToInt32(dataGridView2.Rows[i].Cells[5].Value);
                timi = Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                fpa = Convert.ToInt32(dataGridView2.Rows[i].Cells[4].Value);
       
                sumwithfpa += (posotita * timi);
                sumwithoutfpa += posotita * (timi - ((fpa * timi) / 100));
            }
            eminan = apothema - posotita;
            label30.Text = sumwithfpa.ToString();
            label32.Text = eminan.ToString();


        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {

            cmdbl = new SqlCommandBuilder(daPel);
            daPel.Fill(dsPel,"Pelates_Table");
            MessageBox.Show("Information Updated");




        }

        public void refreshImage()
        {
            String photoPath = textBox12.Text.Trim();
            if (photoPath != null && File.Exists(photoPath))
            {
                pictureBox1.Image = Image.FromFile(photoPath);
            }
            else
            {
                pictureBox1.Image = Image.FromFile(@"D:\Πανεπιστήμιο\Θεωρίες Τ.Ε.Ι\6o Εξάμηνο Θεωρίες(Μηχανικοί Λογισμικού)\Βάσεις Δεδομένων 2\ProjectDatabase\error-404.png");
            }
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {
            refreshImage();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String openPath;
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                 openPath = openFileDialog1.InitialDirectory +
                 openFileDialog1.FileName;
                 textBox12.Text = openPath;
                 pictureBox1.Image = Image.FromFile(openPath);
                 PhotoUpdate = new SqlCommand("update PELATES set FOTO ='" + openPath + "'where KOD_PELATH=" + textBox24.Text + ";", con);
                 PhotoUpdate.ExecuteNonQuery();
}


        }

        private void saveToolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripButton1_Click(object sender, EventArgs e)
        {

        }




    }
}
