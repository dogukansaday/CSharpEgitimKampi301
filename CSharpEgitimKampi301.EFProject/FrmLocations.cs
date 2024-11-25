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
    public partial class FrmLocations : Form
    {
        public FrmLocations()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Location.ToList();
            dataGridView1.DataSource = values;
        }

        private void FrmLocations_Load(object sender, EventArgs e)
        {
            var values = db.Guied.Select(x => new
            {
                Fullname = x.GuideName + " " + x.GuideSurname,
                x.GuideId
            }).ToList();
            cmbRehber.DisplayMember="FullName";
            cmbRehber.ValueMember = "GuideId";
            cmbRehber.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.LocationCapacity = byte.Parse(nmrKap.Value.ToString());
            location.LocationCity=txtCity.Text;
            location.LocationCountry=txtCauntry.Text;
            location.LocationPrice = decimal.Parse(txtPrice.Text);
            location.DayNight=txtDaily.Text;
            location.GuidedId = int.Parse(cmbRehber.SelectedValue.ToString());
            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Kayıt işlemi başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var deletedValue=db.Location.Find(id);
            db.Location.Remove(deletedValue);
            db.SaveChanges();
            MessageBox.Show("Silme işlemi başarılı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtId.Text);
            var updatedValue = db.Location.Find(id);
            updatedValue.DayNight = txtDaily.Text;
            updatedValue.LocationPrice = decimal.Parse(txtPrice.Text);
            updatedValue.LocationCapacity = byte.Parse(nmrKap.Value.ToString());
            updatedValue.LocationCity = txtCity.Text;
            updatedValue.GuidedId = int.Parse(cmbRehber.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme işlemi başarılı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
