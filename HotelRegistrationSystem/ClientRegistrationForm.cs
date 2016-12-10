using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelRegistrationSystem
{
    public partial class ClientRegistrationForm : Form
    {
        private RoomViewModel roomViewModel;
        private HotelSystemDbContext dbContext;
        private Room selectedRoom;
         
        public ClientRegistrationForm(RoomViewModel roomViewModel, HotelSystemDbContext dbContext)
        {
            InitializeComponent();

            this.roomViewModel = roomViewModel;
            this.dbContext = dbContext;

            this.selectedRoom = this.dbContext.Rooms.Single(r => r.RoomNumber == this.roomViewModel.RoomNumber);
        }
        
        //Проверка при напускане на полето дали то не е празно
        private void nameTextBox_Leave(object sender, EventArgs e)
        {
            if (this.nameTextBox.Text == "")
            {
                MessageBox.Show("Моля въведете име!");
                this.nameTextBox.Focus();
            }
        }

        //Проверка при натискане на клавиш дали той е буква, space или backspace
        private void nameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsLetter(ch) && ch != 8 && ch != 32)
            {
                e.Handled = true;
            }
        }

        //Проверка при напускане на полето дали то не е празно
        private void phoneTextBox_Leave(object sender, EventArgs e)
        {
            if (this.phoneTextBox.Text == "")
            {
                MessageBox.Show("Моля въведете телефон!");
                this.phoneTextBox.Focus();
            }
        }

        //Проверка при натискане на клавиш дали той е цифра или backspace
        private void phoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 107 && ch != '+')
            {
                e.Handled = true;
            }
        }

        private void checkSumButton_Click(object sender, EventArgs e)
        {
            DateTime startDate = this.fromDate.Value;
            DateTime endDate = this.toDate.Value;

            int totalDays = (int)endDate.Subtract(startDate).TotalDays;
            decimal roomPrice = this.selectedRoom.RoomType.Price;

            decimal totalPrice = totalDays * roomPrice;

            this.priseSumTextBox.Text = totalPrice.ToString() + " лв.";
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            string name = this.nameTextBox.Text;
            string phoneNumber = this.phoneTextBox.Text;
            int personId = 0;
            var person = this.dbContext.Persons.SingleOrDefault(p => p.FullName == name);

            if (person == null)
            {
                //add person to DB
                AddPersonToDatabase(name, phoneNumber);

                //get the id of the added person
                var foundPerson = this.dbContext.Persons.Single(p => p.FullName == name);
                personId = foundPerson.Id;

                MessageBox.Show("Created new Person", "New Person with id = " + personId, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                personId = person.Id;
            }

            //register the record
            RegisterNewRecord(personId, this.selectedRoom.Id);

        }

        private void AddPersonToDatabase(string fullName, string phoneNumber)
        {
            Person newPerson = new Person() {
                FullName = fullName,
                PhoneNumber = phoneNumber
            };

            this.dbContext.Persons.Add(newPerson);

            this.dbContext.SaveChanges();
            //int newPersonId = this.dbContext.Persons.
        }

        private void RegisterNewRecord(int personId, int roomId)
        {
            DateTime startDate = this.fromDate.Value;
            DateTime endDate = this.toDate.Value;

            //TODO: CHECK room and person id
            Record newRecord = new Record() {
                PersonId = personId,
                RoomId = roomId,
                BookedFrom = startDate,
                BookedTo = endDate
            };

            this.dbContext.Records.Add(newRecord);

            this.dbContext.SaveChanges();
        }
    }
}
