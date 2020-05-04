<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Project_Glados_master.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>

    .div1 { 
    float: left;
    }
    input[type=text]{
	background-color: DarkOrange;
	height: 30px;
	border: none;
	color: black;
	}
    .button{
	background-color: DarkOrange;
	height: 40px;
	width: 75px;
	text-align:center;
	color: black;
	cursor: pointer;
	border: none;
	}
    select{
	background-color: DarkOrange;
	border: none;
	color: Black;
	}




    </style>
    <title>Project Glados</title>
</head>

<body style="background-color:#181818;" runat="server">
    <div class="div1">
        <img src="https://www.publicdomainpictures.net/pictures/260000/velka/portal.jpg" alt="Aperture Programming" width="150" height="150"/>
    </div>
    <div style="text-align:center; color:RoyalBlue;">
        <h1>Aperture Programming</h1>
        <br/>
        <h2>Project Glados</h2>
        <br/>
    </div>
	<br/>
	<div style="text-align:center; color:RoyalBlue;">
        <p><b><u>Project Glados is an interactive video game catalog. Please enter either: the name, the devloper, or the rating of a game below to look up.</u></b></p>
    </div>

    <div style="margin: auto; align-items: center">
        <form id="form2" runat="server">
            <div style="text-align:right; float: right">
                <div id ="usernameDisplay" runat ="server" >
                </div>
	            <asp:Button ID ="BtnLogout" runat ="server" OnClick="BtnLogout_Click" Text ="Logout" style ="background-color: DarkOrange; text-align:center; color: black; cursor: pointer; border: none;"/>
	        </div>

            <div style="text-align:center">
                <asp:TextBox ID="gameTitle" runat="server" placeholder="Game Title"></asp:TextBox>
                <asp:TextBox ID="gameDeveloper" runat="server" placeholder="Game Developer"></asp:TextBox>
                <asp:DropDownList ID="gameRating" runat="server">
                    <asp:ListItem>Rating</asp:ListItem>
                    <asp:ListItem>0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="Search" />
            </div>

            <br />

            <div>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProjectGladosDBConnectionString3 %>" SelectCommand="SELECT TOP 10 [VideoGameId], [Title], [Price], [Genre], [Company] FROM [VideoGames] WHERE Requested = 0">
                </asp:SqlDataSource>
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" DataSourceID="SqlDataSource1" GridLines="None" HorizontalAlign="Center" Width="75%" AllowSorting="true">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:HyperLinkField DataTextField="Title" DataNavigateUrlFields="VideoGameId" HeaderText="Title" SortExpression="Title" ItemStyle-HorizontalAlign="Center" DataNavigateUrlFormatString="./WebForm3.aspx?VideoGameId={0}"/>
                    <asp:BoundField DataField="Genre" HeaderText="Genre" SortExpression="Genre" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Company" HeaderText="Company" SortExpression="Company" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" ItemStyle-HorizontalAlign="Center"/>
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
          </div>
        </form>
    </div>
</body>
</html>