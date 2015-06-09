<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default2.aspx.cs" Inherits="Cas.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>Welcome <%= User.Identity.Name %> </p>
        <p>
            <% foreach (var item in Request.Cookies)
               {
                   Response.Write(item + "<br>");
               } 
            %> 
        </p>
        <p><a href="../app/home/casauth">Pass Cas Auth to App...</a></p>
    </div>
    </form>
</body>
</html>
