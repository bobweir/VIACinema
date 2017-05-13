<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LoginView ID="LoginViewLogin" runat="server">
        <AnonymousTemplate>
            <div id="login-content">
                <div id="login-1">
                    <img class="login-img" src="./Images/login.png" />
                    <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Home.aspx"></asp:Login>
                </div>
                <div id="wizard-1">
                    <img class="login-img" src="./Images/wizard.png" />
                    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" OnCreatedUser="CreateUserWizard1_CreatedUser">
                        <WizardSteps>
                            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                            </asp:CreateUserWizardStep>
                            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                            </asp:CompleteWizardStep>
                        </WizardSteps>
                    </asp:CreateUserWizard>
                </div>
            </div>
        </AnonymousTemplate>
    </asp:LoginView>
    
   
</asp:Content>


