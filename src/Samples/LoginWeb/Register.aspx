<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
  Inherits="Register" Codebehind="Register.aspx.cs" %>

<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
    <h2>Sign up for a new account</h2>
    
    <asp:CreateUserWizard ID="createUserWizard" runat="server" RequireEmail="false" ContinueDestinationPageUrl="~/Secure/Profile.aspx" 
      CompleteSuccessText="Thank you for creating an account. On the next page we couple your LinkedIn permission to this account."
      InstructionText="When you sign up we couple your LinkedIn permission to this account." HeaderText=""
      ConfirmPasswordLabelText="Confirm Password" PasswordLabelText="Password" UserNameLabelText="User Name"
      QuestionLabelText="Security Question" AnswerLabelText="Security Answer" CreateUserButtonText="Create Account">
      <WizardSteps>
        <asp:CreateUserWizardStep Title="" />
        <asp:CompleteWizardStep Title="" />
      </WizardSteps>
    </asp:CreateUserWizard>

</asp:Content>
