using Antlr.Runtime;
using EstacionamentoCore.Factories;
using EstacionamentoCore.Models.Constants;
using EstacionamentoCore.Models.Parking;
using EstacionamentoCore.Models.Vehicles;
using EstacionamentoCore.Services;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstacionamentoWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               Session["ParkingLot"] = ParkingLotFactory.GetParkingLot(3, 4, 3);

               UpdateParkingSpotsDataSource();
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            SetDetails();
        }

        protected void Park_Click(object sender, EventArgs e)
        {
            var result = ((ParkingLot)Session["ParkingLot"])
                .CreateAndTryParkVehicle(Type.SelectedValue, LicensePlate.Text);

            MessagePanel.Visible = true;
            Message.Text = result.Message;

            LicensePlate.Text = "";
            
            UpdateParkingSpotsDataSource();
            UpdateVehiclesDataSource();
        }

        private void UpdateParkingSpotsDataSource()
        {
            ParkingLot.DataSource = ((ParkingLot)Session["ParkingLot"]).ParkingSpots;
            
            ParkingLot.DataBind();           
        }

        private void UpdateVehiclesDataSource()
        {
            var vehicleList = ((ParkingLot)Session["ParkingLot"]).GetVehicles();
           
            Vehicle.DataSource = vehicleList;
            Vehicle.DataBind();
        }

        protected void Unpark_Click(object sender, EventArgs e)
        {
            var selectedLicensePlate = Vehicle.SelectedItem.Text;

            var result = ((ParkingLot)Session["ParkingLot"]).UnparkVehicleByLicensePlate(selectedLicensePlate);

            MessagePanel.Visible = true;
            Message.Text = result.Message;

            UpdateParkingSpotsDataSource();
            UpdateVehiclesDataSource();
        }

        private void SetDetails()
        {
            var parkingSpot = (ParkingLot)Session["ParkingLot"];

            NumberOfParkingLots.Text = parkingSpot.NumberOfParkingSpots().ToString();
            RemainingParkingLots.Text = parkingSpot.RemainingParkingSpots().ToString();
            IsFull.Text = parkingSpot.IsFull() ? "Sim" : "Não";
            IsEmpty.Text = parkingSpot.IsEmpty() ? "Sim" : "Não";
            AllCarParkingLotsUsed.Text = parkingSpot.AllSpotsUsedBySize(Size.Medium) ? "Sim" : "Não";
            AllMotorbikeParkingLotsUsed.Text = parkingSpot.AllSpotsUsedBySize(Size.Small) ? "Sim" : "Não";
            AllVanParkingLotsUsed.Text = parkingSpot.AllSpotsUsedBySize(Size.Big) ? "Sim" : "Não";
            VansQuantity.Text = parkingSpot.NumberOfVans().ToString();
        }

        protected void BiggerParkingLot_Click(object sender, EventArgs e)
        {
            var parkingLot = ParkingLotFactory.GetParkingLot(10, 10, 10);

            Session["ParkingLot"] = parkingLot;

            UpdateParkingSpotsDataSource();
            UpdateVehiclesDataSource();

            BiggerParkingLot.Visible = false;
            MessagePanel.Visible = false;
        }
    }
}