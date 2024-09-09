<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="EMS.Pages.Employees.View" MasterPageFile="~/EMS.Master"%>

<asp:Content ContentPlaceHolderID="bodyContentPlaceHolder" runat="server" >
    <h3 style="padding-top:6%; padding-left:15%" >Employees</h3>
    <style>
        .grid-header {
            border: 2px solid black;
            background-color: #f0f0f0; /* Optional background color */
        }
        .pagination{
          
            background-color: #cccccc;
            border-radius: 0px 30px 30px 0px;
         
        }
        .pagination:hover{
     /*       background-color:palevioletred;
            border-radius: 100px;
            color:antiquewhite;*/
            
        }
        .grid-row {
            border: 1px solid #CCCCCC;
            height: 20px;
            font-size: 14px;
            text-align: center;
            border:groove ;
        }
        .grid-row:hover {
          /* Optional hover effect */
        }
    </style>
  <form runat="server">  
        <asp:GridView runat="server" ID="employeeGridView" 
            AutoGenerateColumns="false"
            HorizontalAlign="Center" 
            Width="70%"
            OnRowEditing="employeeGridView_RowEditing" 
            OnRowCancelingEdit="employeeGridView_RowCancelingEdit"
            OnRowUpdating="employeeGridView_RowUpdating" 
            OnRowDataBound="employeeGridView_RowDataBound" 
            OnSelectedIndexChanged="employeeGridView_SelectedIndexChanged" 
            AllowPaging="true" 
            PageSize="2"
            OnPageIndexChanging="employeeGridView_PageIndexChanging"
            >
            <HeaderStyle  BorderColor="Black" BorderStyle="Solid" HorizontalAlign="Center"  />
            <RowStyle HorizontalAlign="Center" BorderColor="Black" BorderStyle="Solid" BorderWidth="2" />
            <SelectedRowStyle BackColor="#cccccc" Font-Bold="true" />
         <PagerStyle Font-Bold="true" CssClass="pagination" />
            <Columns >
                <asp:CommandField ShowSelectButton="true" HeaderStyle-BorderWidth="2" HeaderText="Show Details" SelectText="View Details" />

                <asp:BoundField DataField="id" HeaderStyle-BorderWidth="2"  HeaderText="Employee ID" ReadOnly="true"/>
                <asp:BoundField DataField="name" HeaderStyle-BorderWidth="2"  HeaderText="Employee Name"/>
                <asp:BoundField DataField="address" HeaderStyle-BorderWidth="2" HeaderText="Address"/>
                <asp:BoundField DataField="designation" HeaderStyle-BorderWidth="2" HeaderText="Designation"/>
               <asp:TemplateField HeaderText="Department" HeaderStyle-BorderWidth="2">
                   <ItemTemplate>
                       <asp:Label ID="lblDepartmentId" runat="server" Text='<%# Eval("deptId") %>' Visible="false"></asp:Label>
                       <asp:DropDownList runat="server" class="form-select" ID="ddldepartment">
                        <asp:ListItem>Select...</asp:ListItem>
                        <asp:ListItem Value="1" Text="HR">HR</asp:ListItem>
                        <asp:ListItem Value="2" Text="Finance">Finance</asp:ListItem>
                        <asp:ListItem Value="3" Text="Marketing">Marketing</asp:ListItem>
                        <asp:ListItem Value="4" Text="IT">IT</asp:ListItem>
                    </asp:DropDownList>
                   </ItemTemplate>
               </asp:TemplateField>
                  <asp:TemplateField HeaderText="More Details" HeaderStyle-BorderWidth="2">
                   <ItemTemplate>
                      Salray: <asp:Label ID="lblSalary" runat="server" Text='<%# Eval("salary") %>' ></asp:Label> <br />
                      Tenure: <asp:Label ID="lblTenure" runat="server" Text='<%# Eval("tenure") %>' ></asp:Label>                
                   </ItemTemplate>
                      <EditItemTemplate>
                       Salray: <asp:TextBox ID="textSalary" runat="server" Text='<%# Eval("salary") %>' ></asp:TextBox> <br />
                       Tenure: <asp:TextBox ID="textTenure" runat="server" Text='<%# Eval("tenure") %>' ></asp:TextBox>  
                      </EditItemTemplate>
               </asp:TemplateField>
                <asp:CheckBoxField DataField="isAdmin" HeaderStyle-BorderWidth="2" HeaderText="Permission"/>
                <asp:CommandField ShowEditButton="true" ButtonType="Button" HeaderText="Update" HeaderStyle-BorderWidth="2"/>

            </Columns>
        </asp:GridView>
  </form>
    <p id="content" runat="server"></p>
</asp:Content>
