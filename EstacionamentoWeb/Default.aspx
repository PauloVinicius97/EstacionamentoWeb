<%@ Page Title="Estacionamento" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EstacionamentoWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="ParkingLotList" runat="server">
        <asp:GridView 
            ID="ParkingLot" 
            runat="server" 
            AutoGenerateColumns="False" 
            EmptyDataText="Vazio" 
            CssClass="table">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Nome" ReadOnly="True" />
                <asp:BoundField DataField="Size" HeaderText="Tamanho" ReadOnly="True" />
                <asp:BoundField DataField="Vehicle.LicensePlate" HeaderText="Placa do veículo" ReadOnly="True" />
                <asp:BoundField DataField="Vehicle.Type" HeaderText="Tipo do veículo" ReadOnly="True" />
            </Columns>
        </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="MessagePanel" CssClass="container d-flex justify-content-center" runat="server" Visible="false">
        <p class="lead" style="font-weight: bold"><asp:Label ID="Message" runat="server" /></p>
    </asp:Panel>

    <div class="row g-3">
        <asp:Panel ID="ParkVehicle" runat="server" CssClass="col-md-4 d-flex flex-column align-self-start">
            <h2>Estacionar</h2>

            <asp:Label CssClass="my-1" Text="Placa do carro: " runat="server" />
            <asp:TextBox ID="LicensePlate" ValidationGroup="LicensePlateValidator" runat="server" />
            <asp:RequiredFieldValidator ControlToValidate="LicensePlate" 
                Display="static" 
                ErrorMessage="Placa necessária."  
                ForeColor="red" 
                ValidationGroup="LicensePlateValidator" CssClass="my-0"
                runat="server" />

            <asp:Label CssClass="my-1" Text="Tipo: " runat="server" />
            <asp:DropDownList ID="Type" runat="server">
                <asp:ListItem Text="Moto" />
                <asp:ListItem Text="Carro" />
                <asp:ListItem Text="Van" />
            </asp:DropDownList>

            <asp:Button ID="Park" CssClass="my-4 btn btn-primary btn-md" Text="Estacionar" ValidationGroup="LicensePlateValidator" OnClick="Park_Click" runat="server" />
        </asp:Panel>

        <asp:Panel ID="RemoveVehicle" runat="server" CssClass="col-md-4 d-flex flex-column">
            <h2>Remover</h2>
            
            <asp:Label CssClass="my-1" Text="Selecione o veículo: " runat="server" />
            
            <asp:DropDownList ID="Vehicle" DataTextField="LicensePlate" runat="server" />
            <asp:RequiredFieldValidator ControlToValidate="Vehicle" 
                Display="static" 
                ErrorMessage="Selecione um veículo." 
                ForeColor="red"
                ValidationGroup="VehicleValidator"
                runat="server" />
        
            <asp:Button ID="Unpark" Text="Remover do estacionamento" ValidationGroup="VehicleValidator" OnClick="Unpark_Click" CssClass="my-2 btn btn-primary btn-md" runat="server" />
        </asp:Panel>

        <asp:Panel ID="Details" runat="server" CssClass="col-md-4 d-flex flex-column">
            <h2>Detalhes</h2>

            <div>
                <asp:Label Text="Número de vagas: " runat="server" /> 
                <asp:Label ID="NumberOfParkingLots" runat="server" />
            </div>

            <div>
                <asp:Label Text="Vagas restantes: " runat="server" /> 
                <asp:Label ID="RemainingParkingLots" runat="server" />
            </div>

            <div>
                <asp:Label Text="Está vazio: " runat="server" /> 
                <asp:Label ID="IsEmpty" runat="server" />
            </div>

            <div>
                <asp:Label Text="Está lotado: " runat="server" /> 
                <asp:Label ID="IsFull" runat="server" />
            </div>

            <div>
                <asp:Label Text="Todas as vagas de carro ocupadas: " runat="server" /> 
                <asp:Label ID="AllCarParkingLotsUsed" runat="server" />
            </div>

            <div>
                <asp:Label Text="Todas as vagas de moto ocupadas: " runat="server" /> 
                <asp:Label ID="AllMotorbikeParkingLotsUsed" runat="server" />
            </div>

            <div>
                <asp:Label Text="Todas as vagas de van ocupadas: " runat="server" /> 
                <asp:Label ID="AllVanParkingLotsUsed" runat="server" />
            </div>

            <div>
                <asp:Label Text="Número de vans: " runat="server" /> 
                <asp:Label ID="VansQuantity" runat="server" />
            </div>

            <div class="d-flex flex-column">
                <asp:Button ID="BiggerParkingLot" 
                    Text="Gerar estacionamento maior" 
                    OnClick="BiggerParkingLot_Click" 
                    CssClass="my-4 btn btn-primary btn-md"
                    runat="server" />
            </div>
        </asp:Panel>
    </div>
</asp:Content>
