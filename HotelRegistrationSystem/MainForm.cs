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
    public partial class MainForm : Form
    {
        private HotelSystemDbContext dbContext;
        private string roomType;
        private DateTime dateFrom;
        private DateTime dateTo;

        public MainForm()
        {
            InitializeComponent();

            //init the EF dbContext
            this.dbContext = new HotelSystemDbContext();

            // Load data
            this.roomTypeComboBox.DataSource = this.dbContext.RoomTypes.Select(x => x.Name).ToList();
        }

        private void roomTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.roomType = this.roomTypeComboBox.SelectedItem.ToString();
        }

        private void hotelEntriesGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var selectedRoomViewModel = (RoomViewModel)this.hotelEntriesGridView.SelectedRows[0].DataBoundItem;

            var clientRegistrationForm = new ClientRegistrationForm(selectedRoomViewModel, this.dbContext);
            clientRegistrationForm.Show();
        }

        private void loadListButton_Click(object sender, EventArgs e)
        {
            this.dateFrom = this.searchDateFromDateTimePicker.Value.Date;
            this.dateTo = this.searchDateToDateTimePicker.Value.Date;
            
            var query = this.dbContext.Rooms
                    .ToList()
                    .Where(
                        room =>
                            room.RoomType.Name == this.roomType &&
                            this.IsRoomAvailable(room.Records.ToList(), this.dateFrom, this.dateTo)
                        );

            var queryString = query.ToString();

            var result = query
                        .ToList()
                        .Select(
                            room =>
                                new RoomViewModel
                                {
                                    RoomNumber = room.RoomNumber,
                                    RoomType = room.RoomType.Name
                                })
                         .ToList();

            //var records = this.dbContext.Records
            //    .Where(x => (x.Room.RoomType.Name == roomType) && (x.BookedTo >= DateTime.Today)).ToList();

            //var result = records.Where(y => !(y.BookedTo <= this.dateFrom && this.dateTo <= y.BookedFrom))
            //    .Select(x => new RoomViewModel
            //    {
            //        RoomNumber = x.Room.RoomNumber,
            //        RoomType = x.Room.RoomType.Name
            //    })
            //    .ToList();

            //var records = this.dbContext.Records
            //    .Where(x => (x.Room.RoomType.Name == this.roomType) && (x.BookedTo < DateTime.Now)).ToList();


            //MessageBox.Show("Dates...", this.dateTo.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            //// fix the search free rooms
            //var result = records.Where(y => !((y.BookedFrom <= this.dateFrom &&  this.dateFrom <= y.BookedTo) &&
            //            (this.dateFrom < this.dateTo && this.dateTo <= y.BookedTo)))
            //    .Select(x => new RoomViewModel
            //    {
            //        RoomNumber = x.Room.RoomNumber,
            //        RoomType = x.Room.RoomType.Name
            //    })
            //    .ToList();

            this.hotelEntriesGridView.DataSource = result;

            // change columns headers
            DataGridViewCustomColumnNames(this.hotelEntriesGridView);
        }

        private void DataGridViewCustomColumnNames(DataGridView view)
        {
            view.Columns[0].HeaderText = "№";
            view.Columns[1].HeaderText = "Тип стая";
        }

        //private bool IsRoomAvailable(ICollection<Record> records, DateTime dateFrom, DateTime dateTo)
        //{
        //    foreach (var record in records)
        //    {
        //        if (dateFrom > record.BookedFrom &&
        //            dateFrom > record.BookedTo &&
        //            dateTo < record.BookedFrom &&
        //            dateTo < record.BookedFrom)
        //        {
        //            return true;
        //        }
        //    }

        //    return true;
        //}

        private DateTime ConvertFullDateToDate(DateTime dt)
        {
            DateTime resultDate = new DateTime(dt.Year, dt.Month, dt.Day);

            return resultDate;
        }

        private bool IsRoomAvailable(List<Record> records, DateTime start, DateTime end)
        {
            records = records.OrderBy(r => r.BookedFrom).ToList();

            var hits = new List<RoomStruct>();
            var hit = new RoomStruct();
            hit.bookedFrom = records.First().BookedFrom;
            hit.bookedTo = records.First().BookedTo;

            //if the room was booked only 1 time
            if (records.Count == 1)
            {
                var record = records.First();

                if (record.BookedTo < start ||
                    end < record.BookedFrom)
                {
                    return true;
                }
            }

            for (int i = 1; i < records.Count; i++)
            {
                var current = records[i];

                // check for last day of the month and last month of the year
                if ((current.BookedFrom.Day == hit.bookedTo.Day || current.BookedFrom.Day - 1 == hit.bookedTo.Day) 
                    //&&
                    //(current.BookedFrom.Month == hit.bookedTo.Month) &&
                    //(current.BookedFrom.Year == hit.bookedTo.Month)
                    )
                {
                    hit.bookedTo = current.BookedTo;
                }
                else
                {
                    hits.Add(hit);
                    hit = new RoomStruct()
                    {
                        bookedFrom = current.BookedFrom,
                        bookedTo = current.BookedTo
                    };
                }
            }

            for (var i = 0; i < hits.Count - 1; i++)
            {
                var current = hits[i];
                var next = hits[i + 1];

                if (current.bookedTo <= start && end <= next.bookedFrom)
                {
                    return true;
                }
            }

            return false;
        }
    }
}