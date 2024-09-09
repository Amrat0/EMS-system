<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="EMS.Pages.Employees.Add" MasterPageFile="~/EMS.Master" %>


    <asp:Content ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
        <style>
       
            .addEdit{
                margin-top:5px;
                left:10%;
                width:80%;
            }
        </style>
        <div class="card addEdit"   > 
        <div class="card-body">
            <h5 class="card-title" style="font-weight:700;text-align:center;background-color:antiquewhite; border-radius:10px;">ADD-EMPLOYEE</h5>

            <form id="employeeForm" class="row g-3" runat="server">
                  <div class="col-md-6">
                    <label for="name" class="form-label">User Name</label>
                    <asp:TextBox id ="txtUserName" CssClass ="form-control" runat ="server" placeholder="Enter Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="validateUserNm" runat="server" ControlToValidate="txtName" ErrorMessage="User Name is a required field" EnableClientScript="true"></asp:RequiredFieldValidator>
                    </div>

                 <div class="col-md-6">
                    <label for="name" class="form-label">Name</label>
                    <asp:TextBox id ="txtname" CssClass ="form-control" runat ="server" placeholder="Enter Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="nameReq" runat="server" ControlToValidate="txtName" ErrorMessage="Name is a required field" EnableClientScript="true"></asp:RequiredFieldValidator>
                    </div>

                <div class="col-md-6">
                    <label for="password" class="form-label">Password</label>
                    <asp:TextBox type="password" class="form-control" id="txtpassword" runat="server"></asp:TextBox>
                </div>
                <div class="col-12">
                    <label for="address" class="form-label">Address</label>
                    <asp:TextBox runat="server" class="form-control" id="txtaddress"  placeholder="1234 Main St"></asp:TextBox>
                </div>
               
                <div class="col-md-6">
                    <label for="designation" class="form-label">Designation</label>
                    <asp:TextBox runat="server" class="form-control" id="txtdesignation"/>
                </div>
                <div class="col-md-4">
                    <label for="inputState" class="form-label">Department</label>
                    <asp:DropDownList runat="server" class="form-select" ID="ddldepartment">
                        <asp:ListItem>Select...
                        </asp:ListItem>
                    </asp:DropDownList>
                
                </div>
                <div class="col-12">
                    <div class="form-check">
                        <asp:CheckBox runat="server" class="form-check-input" id="isAdmin" />
                        <label class="form-check-label" for="isAdmin">
                           Is Admin
                        </label>
                    </div>
                </div>
                <div class="col-12">
                    <asp:Button runat="server" type="submit" class="btn btn-primary" Text="Create Employee" ID="createEmployee"  OnClick="createEmployee_Click"/>
                </div>
            </form>

        </div>
        <p id="message" runat="server"></p>
    </div>
    </asp:Content>
    
