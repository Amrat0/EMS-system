<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="EMS.Pages.Home" MasterPageFile="~/EMS.Master" %>

<asp:Content ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <style>
      
       .homeScreen {
            object-fit: fill;
            width: 100%;
            height: 90.7vh;
            position: relative; 
        }
        
        .overlay-text {
            position: absolute; 
            top: 60%; 
            left: 45%; 
            width:50px;
            transform: translate(-50%, -50%); 
            color: white; 
            font-size: 2em;
            text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.6); 
            padding: 10px; 
            background: rgb(255 73 104 / 0.3); 
            border-radius: 5px; 
        }

      }
    </style>
    <img src="../Assets/img/wind.gif" class="homeScreen"   alt="Employee Photo"  />
    <div class="overlay-text">EMPLOYEE MANAGEMENT SYSTEM</div>
</asp:Content>
