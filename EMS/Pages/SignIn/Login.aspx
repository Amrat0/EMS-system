<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EMS.Login" MasterPageFile="~/EMS.Master" %>
<asp:Content ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title></title>
    <link href="~/Assets/bootstrap/css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form runat="server" style="width:50%; padding-top:50px; padding-left:25px;">
        <h3 style="border-bottom-style:groove;" >LOGIN</h3>

        <div class="row mb-3">
            <label for="txtuserName" class="col-sm-2 col-form-label">User Name</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" class="form-control" id="txtuserName" />
            </div>
        </div>
        <div class="row mb-3">
            <label for="txtpassword" class="col-sm-2 col-form-label">Password</label>
            <div class="col-sm-10">
                <asp:TextBox type="password" class="form-control" id="txtpassword" runat="server"/>
            </div>

        </div>
        <asp:Button ID="submit"  class="btn btn-primary" Text="Sign in" runat="server" OnClick="submit_Click"/>
         
      
    </form>
    <p id="output" runat="server"></p>
</body>
</html>


    
</asp:Content>
