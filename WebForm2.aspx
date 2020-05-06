<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Project_Glados_master.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>

	.div1 {float: left;}

	.button{
		background-color: DarkOrange;
		text-align:center;
		color: black;
		cursor: pointer;
		border: none;
		}
	
	input[type=text]{
		height: 30px;
		width: 25%;
		border: none;
		background-color:DarkOrange;
		color: Black;
		}

	input[type=submit]{
		border: none;
		color: black;
		cursor: pointer;
		}

	</style>

<title>Project Glados Login Page</title>
</head>

<body style="background-color:#181818;">



<div class="div1">
        <img src="https://www.publicdomainpictures.net/pictures/260000/velka/portal.jpg" alt="Aperture Programming" width="150" height="150"/>
    </div>


	<div style="text-align:center; color:RoyalBlue">
	<h1>Aperture Programming</h1>
	<h2>Project Glados</h2>
	<h3>Login</h3>
	<br/>
	
	</div>

	<div style="text-align:right">
	<button class="button">Back to Main</button>
	</div>
	<br/>
	<br/>

	<form>
	<div style="color:RoyalBlue">
	<label for="UserName">Username:</label>
	<br/>
	<input type="text" id="UserName" name="UserName" placeholder="UserName"/>
	<br/>
	<br/>
	<label for="pW">Password:</label>
	<br/>
	<input type="text" id="pW" name="pW" placeholder="Password"/>
	<br/>
	<br/>
	<input type="submit" value="Submit"/>
	</div>
	</form>


</body>
</html>
