using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {

            var values = db.Guied.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Guied guide = new Guied();
            guide.GuideName=txtName.Text;
            guide.GuideSurname = txtSurName.Text;
            db.Guied.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Kayıt başarıyla eklendi","Bilgi");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id =int.Parse( txtId.Text);
            var removeValue = db.Guied.Find(id);
            db.Guied.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Kayıt başarıyla silindi.","Uyarı!!");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
int id=int.Parse( txtId.Text);
            var updateValue = db.Guied.Find(id);
            updateValue.GuideName=txtName.Text;
            updateValue.GuideSurname=txtSurName.Text;
            db.SaveChanges();
            MessageBox.Show("Kayıt başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id=int.Parse( txtId.Text);
            var values =db.Guied.Where(x=>x.GuideId==id).ToList();
            dataGridView1.DataSource = values;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }
    }
}
