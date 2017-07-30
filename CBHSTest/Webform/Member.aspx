<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Webform.WebForm1" UnobtrusiveValidationMode="None" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- START PAGE PLUGINS-->

    <link href="Content/css/theme-default.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/plugins/jquery/jquery.min.js"></script>
    <script type="text/javascript" src="js/plugins/jquery/jquery-ui.min.js"></script>
    <script type="text/javascript" src="js/plugins/bootstrap/bootstrap.min.js"></script>
    <script type='text/javascript' src='js/plugins/icheck/icheck.min.js'></script>
    <script type="text/javascript" src="js/plugins/mcustomscrollbar/jquery.mCustomScrollbar.min.js"></script>
    <script type="text/javascript" src="js/demo_tables.js"></script>
    <script type="text/javascript" src="js/settings.js"></script>
    <script type="text/javascript" src="js/plugins.js"></script>
    <script type="text/javascript" src="js/actions.js"></script>
    <script type="text/javascript" src="js/plugins/bootstrap/bootstrap-datepicker.js"></script>

    <!-- END PLUGINS -->

</head>
<body>
    <form id="form1" class="form-horizontal" runat="server">
        <div class="page-content-wrap">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title"><strong>Add Members</strong></h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="col-md-3 control-label">First Name</label>
                                        <div class="col-md-9">
                                            <div class="input-group">
                                                <input type="text" runat="server" id="txtFirstName" class="form-control" />
                                                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                                                    ForeColor="Red" ErrorMessage="Please Enter First Name" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-3 control-label">Email</label>
                                        <div class="col-md-9">
                                            <div class="input-group">
                                                <input type="text" runat="server" id="txtEmail" class="form-control" />
                                                <asp:RegularExpressionValidator ID="rgvEmail"
                                                    runat="server" ErrorMessage="Please Enter Valid Email ID"
                                                    ValidationGroup="vgSubmit" ControlToValidate="txtEmail"
                                                    ForeColor="Red" Display="Dynamic"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                                </asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="col-md-3 control-label">Last Name</label>
                                        <div class="col-md-9">
                                            <div class="input-group">
                                                <input type="text" runat="server" id="txtLastName" class="form-control" />
                                                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName"
                                                    ForeColor="Red" ErrorMessage="Please Enter Last Name" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-3 control-label">Date of Birth</label>
                                        <div class="col-md-9">
                                            <div class="input-group">
                                                <input type="text" runat="server" id="datepicker" class="form-control datepicker" />
                                                <asp:RequiredFieldValidator ID="rfvdatepicker" runat="server" ControlToValidate="datepicker"
                                                    ForeColor="Red" ErrorMessage="Please Enter Date" Display="Dynamic"></asp:RequiredFieldValidator>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <asp:Button runat="server" ID="addMember" class="btn btn-primary pull-right" Text="Add" OnClick="addMember_Click"></asp:Button>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title"><strong>Members</strong></h3>
                    </div>
                    <div class="panel-body">
                        <asp:GridView ID="GridView1" runat="server" class="table table-striped table-hover" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="MemberID">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="First Name" DataField="FirstName"
                                    SortExpression="FirstName"></asp:BoundField>
                                <asp:BoundField HeaderText="Last Name" DataField="LastName"
                                    SortExpression="LastName"></asp:BoundField>
                                <asp:BoundField HeaderText="Email" DataField="Email"
                                    SortExpression="LastName"></asp:BoundField>
                                <asp:BoundField HeaderText="Date of Birth" DataField="DateOfBirth"
                                    SortExpression="DateOfBirth" DataFormatString="{0:d}"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="panel-heading">
                        <h2 class="panel-title">Oldest Member:</h2>
                        <div class="col-sm-7">
                            <label runat="server" id="lblOldestMember" class="control-label"></label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
