<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SC.Recaptcha.Sample.WebForms.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>SC.Recaptcha.WebForms Sample</title>
</head>
<body>
	<h1>Are you a robot?</h1>
	<p>Proof if you aren't!</p>
	<form id="frmMain" runat="server">
		<p><asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red" /></p>

		<div class="g-recaptcha" data-sitekey="6Ld1MQoTAAAAAPZbyzS8zz1aaUug4at6bna2vJ7B"></div>

		<%-- Browser default language will be used to display Recaptcha control--%>
		<script async="true" defer="true" src="https://www.google.com/recaptcha/api.js"></script>

		<%-- Following line show example how to display Recaptcha control in specific language
		<script async="true" defer="true" src="https://www.google.com/recaptcha/api.js?hl=de"></script>--%>

		<br />
		<asp:Button ID="btnClickMe" runat="server" Text="Click Me" OnClick="btnClickMe_Click" />
	</form>
</body>
</html>
